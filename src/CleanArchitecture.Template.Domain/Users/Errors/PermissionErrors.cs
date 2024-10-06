using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class PermissionErrors
    {
        public static Error InvalidName => Error.Validation($"{nameof(Permission)}.Invalid", "Name name cannot be empty or null.");
        public static Error InvalidDescription => Error.Validation($"{nameof(Permission)}.Invalid", "Description cannot be empty or null.");

    }
}
