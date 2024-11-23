using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Emails;
using CleanArchitecture.Template.Domain.Users.ValueObjects.FullNames;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Usernames;
using FluentValidation;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Username)
             .NotEmpty().WithMessage("Username is required.")
             .Length(UsernameConstants.MinLength, UsernameConstants.MaxLength)
             .WithMessage($"Username must be between {UsernameConstants.MinLength} and {UsernameConstants.MaxLength} characters.");

        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("A valid email is required.")
           .MaximumLength(EmailConstants.MaxLength)
           .WithMessage($"Email must not exceed {EmailConstants.MaxLength} characters.");

        RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password is required.")
             .Custom((password, context) =>
             {
                 var validationResult = Password.Validate(password);
                 if (validationResult.IsFailure)
                 {
                     context.AddFailure(validationResult.Error.Description);
                 }
             });

        RuleFor(x => x.FirstName)
             .NotEmpty()
             .MaximumLength(FullNameConstants.FirstNameMaxLength).WithMessage($"First name must not exceed {FullNameConstants.FirstNameMaxLength} characters.");

        RuleFor(x => x.LastName1)
             .NotEmpty()
             .MaximumLength(FullNameConstants.LastNameMaxLength).WithMessage($"Last name must not exceed {FullNameConstants.LastNameMaxLength} characters.");
    }
}
