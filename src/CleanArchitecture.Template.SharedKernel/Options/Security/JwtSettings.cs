namespace CleanArchitecture.Template.SharedKernel.Options.Security
{
    public class JwtSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int ExpirationDateInDays { get; set; }
    }
}
