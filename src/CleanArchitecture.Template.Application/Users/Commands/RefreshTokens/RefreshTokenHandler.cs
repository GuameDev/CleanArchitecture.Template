using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Commands.RefreshTokens.DTO;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Commands.RefreshTokens
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthTokenService _authTokenService;

        public RefreshTokenHandler(IUnitOfWork unitOfWork, IAuthTokenService authTokenService)
        {
            _unitOfWork = unitOfWork;
            _authTokenService = authTokenService;
        }

        public async Task<Result<RefreshTokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the refresh token
            var refreshToken = await _unitOfWork.RefreshTokenRepository.GetBySpecificationAsync(
                new RefreshTokenByTokenSpecification(request.Token));

            if (refreshToken == null || refreshToken.IsRevoked || refreshToken.ExpirationDate < DateTime.UtcNow)
                return Result.Failure<RefreshTokenResponse>(RefreshTokenErrors.TokenInvalidOrExpired);

            // Revoke the old token
            refreshToken.Revoke();
            _unitOfWork.RefreshTokenRepository.Update(refreshToken);

            // Generate new tokens
            var user = refreshToken.User;
            var newAccessTokenResponse = _authTokenService.GenerateAccessToken(user);
            var newRefreshTokenResponse = _authTokenService.GenerateRefreshToken();

            // Create and save the new refresh token
            var newRefreshToken = RefreshToken.Create(
                newRefreshTokenResponse.Token,
                newRefreshTokenResponse.ExpirationDate,
                user);

            if (newRefreshToken.IsFailure)
                return Result.Failure<RefreshTokenResponse>(newRefreshToken.Error);

            await _unitOfWork.RefreshTokenRepository.AddAsync(newRefreshToken.Value);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new RefreshTokenResponse(
                new(newAccessTokenResponse.Token, newAccessTokenResponse.ExpirationDate),
                new(newRefreshTokenResponse.Token, newRefreshTokenResponse.ExpirationDate)));
        }
    }
}
