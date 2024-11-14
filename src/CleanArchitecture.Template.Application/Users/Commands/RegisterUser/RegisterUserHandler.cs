using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.Users.Specifications;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords;
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
            var specification = new UserByEmailOrUsernameSpecification(request.Email, request.Username);
            bool userAlreadyExist = await _unitOfWork.UserRepository.ExistAsync(specification);

            if (userAlreadyExist)
                return Result.Failure<RegisterUserResponse>(UserErrors.UserAlreadyExist);

            var passwordResult = Password.Create(request.Password);

            if (passwordResult.IsFailure)
                return Result.Failure<RegisterUserResponse>(passwordResult.Error);

            var password = passwordResult.Value;
            var passwordHash = _passwordHasher.Hash(password.Value);

            var userResult = User.Create(
                request.Username,
                request.Email,
                passwordHash,
                request.FirstName,
                request.LastName1,
                request.LastName2);

            if (userResult.IsFailure)
                return Result.Failure<RegisterUserResponse>(userResult.Error);

            var user = userResult.Value;

            var defaultRole = await _unitOfWork.RoleRepository.GetByNameAsync(RoleName.User);

            if (defaultRole is null)
                return Result.Failure<RegisterUserResponse>(UserErrors.DefaultRoleNotFound);

            user.AddRole(defaultRole);

            // Save the user
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new RegisterUserResponse(user.Id, user.Username.Value));
        }

    }
}
