namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords
{
    public static class PasswordConstants
    {
        public const int MaxLength = 100;
        public const int MinLength = 8;

        public const string UppercaseRegex = @"[A-Z]";
        public const string LowercaseRegex = @"[a-z]";
        public const string MissingDigitRegex = @"[0-9]";
        public const string SpecialCharacterRegex = @"[\W_]";
    }
}
