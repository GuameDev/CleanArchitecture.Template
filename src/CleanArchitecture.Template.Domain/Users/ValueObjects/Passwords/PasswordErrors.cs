using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords
{
    public static class PasswordErrors
    {
        public static readonly Error EmptyPassword = Error.Validation("Password.Empty", "Password cannot be empty.");
        public static readonly Error MinLength = Error.Validation("Password.MinLength", $"Password must be at least {PasswordConstants.MinLength} characters long.");
        public static readonly Error MaxLength = Error.Validation("Password.MaxLength", $"Password can´t be larger than {PasswordConstants.MaxLength} characters long.");

        public static readonly Error MissingUppercase = Error.Validation("Password.MissingUppercase", "Password must contain at least one uppercase letter.");
        public static readonly Error MissingLowercase = Error.Validation("Password.MissingLowercase", "Password must contain at least one lowercase letter.");
        public static readonly Error MissingDigit = Error.Validation("Password.MissingDigit", "Password must contain at least one digit.");
        public static readonly Error MissingSpecialCharacter = Error.Validation("Password.MissingSpecialCharacter", "Password must contain at least one special character.");
    }
}
