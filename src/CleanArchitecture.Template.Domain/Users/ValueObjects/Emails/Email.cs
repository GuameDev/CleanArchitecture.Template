using CleanArchitecture.Template.Domain.Users.ValueObjects.Emails;
using CleanArchitecture.Template.SharedKernel.Results;
using System.Text.RegularExpressions;

public class Email : ValueObject
{
    public string Value { get; init; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Email>(EmailErrors.InvalidEmail);

        if (email.Length > EmailConstants.MaxLength)
            return Result.Failure<Email>(EmailErrors.MaxLength);

        // Regex pattern for email validation
        var emailRegex = new Regex(EmailConstants.ValidEmailRegex);
        if (!emailRegex.IsMatch(email))
            return Result.Failure<Email>(EmailErrors.InvalidEmailFormat);

        // Additional check for consecutive dots (..)
        if (email.Contains(EmailConstants.InvalidFormat))
            return Result.Failure<Email>(EmailErrors.InvalidEmailFormat);

        return Result.Success(new Email(email));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
