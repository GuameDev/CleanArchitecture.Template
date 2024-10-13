namespace CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs
{
    public record RegisterUserRequest(string Username, string Email, string FirstName, string LastName1, string? LastName2, string Password);
}
