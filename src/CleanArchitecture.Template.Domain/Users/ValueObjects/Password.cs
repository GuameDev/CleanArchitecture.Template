using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.SharedKernel.Results;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; }

        private Password(string value)
        {
            Value = value;
        }

        // Factory method to create a password with strong validation
        public static Result<Password> Create(string plainPassword)
        {
            var validationResult = Validate(plainPassword);
            if (validationResult.IsFailure)
                return validationResult;

            return Result.Success(new Password(plainPassword));
        }

        // Extract validation logic into a separate method
        public static Result<Password> Validate(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return Result.Failure<Password>(PasswordErrors.EmptyPassword);

            if (plainPassword.Length < 8)
                return Result.Failure<Password>(PasswordErrors.MinLengthPassword);

            if (!Regex.IsMatch(plainPassword, @"[A-Z]"))
                return Result.Failure<Password>(PasswordErrors.MissingUppercase);

            if (!Regex.IsMatch(plainPassword, @"[a-z]"))
                return Result.Failure<Password>(PasswordErrors.MissingLowercase);

            if (!Regex.IsMatch(plainPassword, @"[0-9]"))
                return Result.Failure<Password>(PasswordErrors.MissingDigit);

            if (!Regex.IsMatch(plainPassword, @"[\W_]")) // Non-word characters or underscores
                return Result.Failure<Password>(PasswordErrors.MissingSpecialCharacter);

            return Result.Success(new Password(plainPassword));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
