using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Usernames
{
    public static class UsernameErrors
    {
        public static readonly Error EmptyUsername = Error.Validation("User.InvalidUsername", "Username cannot be empty or null.");
        public static readonly Error InvalidUsernameLength = Error.Validation("User.InvalidUsernameLength", $"Username must be between {UsernameConstants.MinLength} and {UsernameConstants.MaxLength} characters.");
    }
}
