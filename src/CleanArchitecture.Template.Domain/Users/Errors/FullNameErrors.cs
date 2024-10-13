using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class FullNameErrors
    {
        public static readonly Error InvalidFullName = Error.Validation("User.InvalidFullName", "First name and last name cannot be empty.");
    }
}
