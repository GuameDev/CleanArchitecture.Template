using System.Security.Cryptography;

namespace CleanArchitecture.Template.Infrastructure.Services.Security
{
    public static class PasswordHasherConstants
    {
        public const int SaltSize = 16;
        public const int HashSize = 32;
        public const int Iterations = 10000;
        public const char Separator = '-';

        public static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA3_512;
    }
}
