namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs
{
    public record LoginUserResponse(LoginUserTokenResponse AccessToken, LoginUserTokenResponse RefreshToken);
}
