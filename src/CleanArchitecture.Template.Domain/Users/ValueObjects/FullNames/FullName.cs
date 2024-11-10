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
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName1))
                return Result.Failure<FullName>(FullNameErrors.InvalidFullName);

            return Result.Success(new FullName(firstName, lastName1, lastName2));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName1;
            yield return LastName2 ?? string.Empty;
        }
    }
}
