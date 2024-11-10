using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Emails
{
    public static class EmailErrors
    {
        public static readonly Error InvalidEmail = Error.Validation("User.InvalidEmail", "Email cannot be empty or null.");
        public static readonly Error InvalidEmailFormat = Error.Validation("User.InvalidEmailFormat", "Email format is invalid.");
    }
}
