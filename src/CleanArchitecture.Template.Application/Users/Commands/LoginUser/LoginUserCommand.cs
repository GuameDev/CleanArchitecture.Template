using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;

namespace CleanArchitecture.Template.Application.Users.Commands.LoginUser
{
    public record LoginUserCommand(string EmailOrUsername, string Password) : ICommand<LoginUserResponse> { }

}
