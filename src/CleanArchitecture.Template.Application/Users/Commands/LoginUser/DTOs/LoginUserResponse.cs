namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs
{
    public record LoginUserResponse(string Token, DateTime ExpirationDate);
}
