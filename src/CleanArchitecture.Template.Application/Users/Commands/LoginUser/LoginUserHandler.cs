using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserPasswordHasher _passwordHasher;
        private readonly IAuthTokenService _authTokenService;

        public LoginUserHandler(
            IUnitOfWork unitOfWork,
            IUserPasswordHasher passwordHasher,
            IAuthTokenService authTokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _authTokenService = authTokenService;
        }
        public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var specification = new UserByEmailOrUsernameSpecification(request.EmailOrUsername);
            var user = await _unitOfWork.UserRepository.GetBySpecificationAsync(specification);

            if (user is null)
                return Result.Failure<LoginUserResponse>(UserErrors.UserNotFound);

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
                return Result.Failure<LoginUserResponse>(UserErrors.UserInvalidCredentials);

            var accessTokenResponse = _authTokenService.GenerateAccessToken(user);
            var refreshTokenResponse = _authTokenService.GenerateRefreshToken();

            var refreshToken = RefreshToken.Create(
                refreshTokenResponse.Token,
                refreshTokenResponse.ExpirationDate,
                user);

            await _unitOfWork.RefreshTokenRepository.AddAsync(refreshToken.Value);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new LoginUserResponse(accessTokenResponse, refreshTokenResponse));
        }
    }
}
