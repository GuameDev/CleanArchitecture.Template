using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;

namespace CleanArchitecture.Template.Application.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string Username,
        string Email,
        string FirstName,
        string LastName1,
        string? LastName2,
        string Password)
        : ICommand<RegisterUserResponse>
    { }

}
