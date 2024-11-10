using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users
{
    public static class UserErrors
    {
        public static Error DefaultRoleNotFound => Error.Conflict($"{nameof(User)}.DefaultRoleNotFound", "Default role User not found.");

        public static Error InvalidPasswordHash => Error.Validation($"{nameof(User)}.InvalidPasswordHash", "Password hash cannot be empty or null.");
        public static Error InvalidUserDetails => Error.Validation("User.InvalidUserDetails", "User details are invalid.");
        public static Error UserAlreadyExist => Error.Problem("User.UserAlreadyExist", "User already exist");
        public static Error UserNotFound => Error.NotFound("User.NotFound", "User not found");
        public static Error UserInvalidCredentials => Error.NotFound("User.InvalidCredentiasl", "Username or password are not valid. Please try again.");
    }
}
