using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.Users.Commands.RefreshTokens.DTO;

namespace CleanArchitecture.Template.Application.Users.Commands.RefreshTokens
{
    public record RefreshTokenCommand(string Token) : ICommand<RefreshTokenResponse> { }
}
