namespace CleanArchitecture.Template.SharedKernel.Options.Security
{
    public class JwtSettings
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }

    public class AccessToken
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int ExpirationDateInMinutes { get; set; }
    }
    public class RefreshToken
    {
        public int ExpirationDateInDays { get; set; }
    }
}
