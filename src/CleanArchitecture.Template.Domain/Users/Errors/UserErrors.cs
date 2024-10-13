using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class UserErrors
    {
        public static Error DefaultRoleNotFound => Error.Conflict($"{nameof(User)}.DefaultRoleNotFound", "Default role User not found.");

        public static Error InvalidPasswordHash => Error.Validation($"{nameof(User)}.InvalidPasswordHash", "Password hash cannot be empty or null.");
        public static Error InvalidUserDetails => Error.Validation("User.InvalidUserDetails", "User details are invalid.");
        public static Error UserAlreadyExist => Error.Problem("User.UserAlreadyExist", "User already exist");
    }
}
