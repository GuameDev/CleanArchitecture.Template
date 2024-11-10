namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs
{
    public record LoginUserTokenResponse(string Token, DateTime ExpirationDate);
}
