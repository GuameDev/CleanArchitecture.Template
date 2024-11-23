using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.FullNames
{
    public class FullName : ValueObject
    {
        public string FirstName { get; init; }
        public string LastName1 { get; init; }
        public string? LastName2 { get; init; }

        private FullName(string firstName, string lastName1, string? lastName2)
        {
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
        }

        public static Result<FullName> Create(string firstName, string lastName1, string? lastName2)
        {
            var validationResult = Validate(firstName, lastName1, lastName2);
            if (validationResult.IsFailure)
                return Result.Failure<FullName>(validationResult.Error);

            return Result.Success(new FullName(firstName, lastName1, lastName2));
        }

        private static Result Validate(string firstName, string lastName1, string? lastName2)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName1))
                return Result.Failure(FullNameErrors.InvalidFullName);

            if (!IsValidLength(firstName, FullNameConstants.FirstNameMinLength, FullNameConstants.FirstNameMaxLength))
                return Result.Failure(FullNameErrors.InvalidFirstNameLength);

            if (!IsValidLength(lastName1, FullNameConstants.LastNameMinLength, FullNameConstants.LastNameMaxLength))
                return Result.Failure(FullNameErrors.InvalidLastName1Length);

            if (!string.IsNullOrEmpty(lastName2) &&
                !IsValidLength(lastName2, FullNameConstants.LastNameMinLength, FullNameConstants.LastNameMaxLength))
                return Result.Failure(FullNameErrors.InvalidLastName2Length);

            return Result.Success();
        }

        private static bool IsValidLength(string value, int minLength, int maxLength)
        {
            return value.Length >= minLength && value.Length <= maxLength;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName1;
            yield return LastName2 ?? string.Empty;
        }
    }
}
