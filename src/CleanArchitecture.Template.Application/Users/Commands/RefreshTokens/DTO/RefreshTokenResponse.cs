namespace CleanArchitecture.Template.Application.Users.Commands.RefreshTokens.DTO
{
    public record RefreshTokenResponse(RefreshTokenResponseItemResponse AccessToken, RefreshTokenResponseItemResponse RefreshToken);
}
