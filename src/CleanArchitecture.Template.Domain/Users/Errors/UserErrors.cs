using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class UserErrors
    {
        public static Error InvalidPasswordHash => Error.Validation($"{nameof(User)}.InvalidPasswordHash", "Password hash cannot be empty or null.");
        public static readonly Error InvalidUserDetails = Error.Validation("User.InvalidUserDetails", "User details are invalid.");
    }
}
