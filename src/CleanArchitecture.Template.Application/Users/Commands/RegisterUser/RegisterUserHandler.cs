using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserPasswordHasher _passwordHasher;

        public RegisterUserHandler(
            IUnitOfWork unitOfWork,
            IUserPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            bool userAlreadyExist = await _unitOfWork.UserRepository.Exist(request.Username, request.Email);

            if (userAlreadyExist)
                return Result.Failure<RegisterUserResponse>(UserErrors.UserAlreadyExist);

            var usernameResult = Username.Create(request.Username);
            var emailResult = Email.Create(request.Email);
            var fullNameResult = FullName.Create(request.FirstName, request.LastName1, request.LastName2);
            var passwordResult = Password.Create(request.Password);

            var valueObjectsResult = Result.Combine(usernameResult, emailResult, fullNameResult, passwordResult);

            if (valueObjectsResult.IsFailure)
                return Result.Failure<RegisterUserResponse>(valueObjectsResult.Error);

            var passwordHash = _passwordHasher.Hash(request.Password);
            var userResult = Domain.Users.User.Create(usernameResult.Value, emailResult.Value, fullNameResult.Value, passwordHash);

            if (userResult.IsFailure)
                return Result.Failure<RegisterUserResponse>(userResult.Error);

            var user = userResult.Value;

            var defaultRole = await _unitOfWork.RoleRepository.GetByNameAsync(RoleName.User);

            if (defaultRole is null)
                return Result.Failure<RegisterUserResponse>(UserErrors.DefaultRoleNotFound);

            user.AddRole(defaultRole);

            // Save the user
            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new RegisterUserResponse(user.Id, user.Username.Value));
        }

    }
}
