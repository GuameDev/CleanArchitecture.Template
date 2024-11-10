using FluentValidation;

namespace CleanArchitecture.Template.Application.Users.Commands.RefreshTokens.DTO
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}
