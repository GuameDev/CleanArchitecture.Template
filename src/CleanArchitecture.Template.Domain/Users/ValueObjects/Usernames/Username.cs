using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Usernames
{
    public class Username : ValueObject
    {
        public string Value { get; init; }

        private Username(string value)
        {
            Value = value;
        }

        // Factory Method with Validation
        public static Result<Username> Create(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Result.Failure<Username>(UsernameErrors.EmptyUsername);

            if (username.Length < 3 || username.Length > 50)
                return Result.Failure<Username>(UsernameErrors.InvalidUsernameLength);

            return Result.Success(new Username(username));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
