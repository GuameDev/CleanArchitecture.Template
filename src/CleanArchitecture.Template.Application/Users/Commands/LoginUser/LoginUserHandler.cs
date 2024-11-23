using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications;
using CleanArchitecture.Template.Domain.Users.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserPasswordHasher _passwordHasher;
        private readonly IAuthTokenService _authTokenService;

        public LoginUserHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IUserPasswordHasher passwordHasher,
            IAuthTokenService authTokenService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
            _authTokenService = authTokenService;
        }
        public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userByEmailOrUsernameSpecification = new UserByEmailOrUsernameSpecification(request.EmailOrUsername);
            var user = await _userRepository.GetBySpecificationAsync(userByEmailOrUsernameSpecification);

            if (user is null)
                return Result.Failure<LoginUserResponse>(UserErrors.UserNotFound);

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
                return Result.Failure<LoginUserResponse>(UserErrors.UserInvalidCredentials);

            var accessTokenResponse = _authTokenService.GenerateAccessToken(user);
            var refreshTokenResponse = _authTokenService.GenerateRefreshToken();

            //TODO: Implement outbox pattern to implement events. maybe we could encappsulate this into a Revoking old refresht tokens handler
            // Revoke existing tokens and add the new refresh token to ensure single device login approach
            var activeRefreshTokenSpecification = new ActiveRefreshTokensByUserIdSpecification(user.Id);
            var oldRefreshTokens = await _refreshTokenRepository.GetListBySpecificationAsync(activeRefreshTokenSpecification);

            foreach (var token in oldRefreshTokens)
            {
                token.Revoke();
                _refreshTokenRepository.Update(token);
            }


            // Attempt to create a new refresh token
            var newRefreshToken = RefreshToken.Create(
                refreshTokenResponse.Token,
                refreshTokenResponse.ExpirationDate,
                user);

            if (newRefreshToken.IsFailure)
                return Result.Failure<LoginUserResponse>(newRefreshToken.Error);


            // Save the new refresh token if creation was successful
            await _refreshTokenRepository.AddAsync(newRefreshToken.Value);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new LoginUserResponse(accessTokenResponse, refreshTokenResponse));
        }


    }
}
