namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs
{
    public record LoginUserRequest(string UsernameOrEmail, string Password);
}
