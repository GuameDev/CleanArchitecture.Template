using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class PermissionErrors
    {
        public static Error PermissionAlreadyAssigned => Error.Conflict($"{nameof(Permission)}.Invalid", "Permission is already assign");
        public static Error PermissionNotAssigned => Error.Validation($"{nameof(Permission)}.Invalid", "Permission is not assigned");

        public static Error InvalidName => Error.Validation($"{nameof(Permission)}.Invalid", "Name name cannot be empty or null.");
        public static Error InvalidDescription => Error.Validation($"{nameof(Permission)}.Invalid", "Description cannot be empty or null.");

    }
}
