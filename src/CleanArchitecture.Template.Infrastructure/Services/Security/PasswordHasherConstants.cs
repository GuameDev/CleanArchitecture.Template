using System.Security.Cryptography;

namespace CleanArchitecture.Template.Infrastructure.Services.Security
{
    //TODO: implement options for this
    public static class PasswordHasherConstants
    {
        public const int SaltSize = 32;
        public const int HashSize = 32;
        public const int Iterations = 150000;
        public const char Separator = '-';

        public static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;
    }
}
