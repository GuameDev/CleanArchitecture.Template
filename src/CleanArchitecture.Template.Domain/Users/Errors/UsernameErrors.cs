using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class UsernameErrors
    {
        public static readonly Error InvalidUsername = Error.Validation("User.InvalidUsername", "Username cannot be empty or null.");
        public static readonly Error InvalidUsernameLength = Error.Validation("User.InvalidUsernameLength", "Username must be between 3 and 50 characters.");
    }
}
