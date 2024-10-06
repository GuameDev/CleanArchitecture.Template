using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class RoleErrors
    {
        public static Error InvalidRoleName => Error.Validation($"{nameof(RoleName)}.Invalid", "Role name cannot be empty or null.");
        public static Error RoleAlreadyAssigned => Error.Problem($"{nameof(User)}.RoleAlreadyAssigned", "Role is already assigned to this user.");
        public static Error RoleNotAssigned => Error.Problem($"{nameof(User)}.RoleNotAssigned", "Role is not assigned to this user.");
    }
}
