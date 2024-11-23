using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.ValueObjects.FullNames
{
    public static class FullNameErrors
    {
        public static readonly Error InvalidFullName = Error.Validation("User.InvalidFullName", "First name and last name cannot be empty.");

        public static readonly Error InvalidFirstNameLength = Error.Validation("User.InvalidFirstNameLength", $"First name must be between {FullNameConstants.FirstNameMinLength} and {FullNameConstants.FirstNameMaxLength} characters.");

        public static readonly Error InvalidLastName1Length = Error.Validation("User.InvalidLastName1Length ", $"Last name 1 must be between {FullNameConstants.LastNameMinLength} and {FullNameConstants.LastNameMaxLength} characters.");

        public static readonly Error InvalidLastName2Length = Error.Validation("User.InvalidLastName2Length ", $"Last name 2 must be between {FullNameConstants.LastNameMinLength} and {FullNameConstants.LastNameMaxLength} characters.");
    }
}
