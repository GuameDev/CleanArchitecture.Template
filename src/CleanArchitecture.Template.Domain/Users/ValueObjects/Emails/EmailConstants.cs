namespace CleanArchitecture.Template.Domain.Users.ValueObjects.Emails
{
    public static class EmailConstants
    {
        public const int MaxLength = 255;
        public const string ValidEmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public const string InvalidFormat = "..";
    }
}
