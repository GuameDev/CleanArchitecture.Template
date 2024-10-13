using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Constants;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using FluentValidation;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Username)
             .NotEmpty().WithMessage("Username is required.")
             .Length(UserValidationConstants.MinUsernameLength, UserValidationConstants.MaxUsernameLength)
             .WithMessage($"Username must be between {UserValidationConstants.MinUsernameLength} and {UserValidationConstants.MaxUsernameLength} characters.");

        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("A valid email is required.")
           .MaximumLength(UserValidationConstants.MaxEmailLength)
           .WithMessage($"Email must not exceed {UserValidationConstants.MaxEmailLength} characters.");

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
             .MaximumLength(UserValidationConstants.MaxNameLength).WithMessage($"First name must not exceed {UserValidationConstants.MaxNameLength} characters.");

        RuleFor(x => x.LastName1)
             .NotEmpty()
             .MaximumLength(UserValidationConstants.MaxNameLength).WithMessage($"Last name must not exceed {UserValidationConstants.MaxNameLength} characters.");
    }
}
