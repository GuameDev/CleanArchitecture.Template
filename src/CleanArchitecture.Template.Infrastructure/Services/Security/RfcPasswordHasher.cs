using CleanArchitecture.Template.Application.Users.Services;
using System.Security.Cryptography;

namespace CleanArchitecture.Template.Infrastructure.Services.Security
{
    public class RfcPasswordHasher : IUserPasswordHasher
    {
        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(PasswordHasherConstants.SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                PasswordHasherConstants.Iterations,
                PasswordHasherConstants.Algorithm,
                PasswordHasherConstants.HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool Verify(string password, string passwordHash)
        {

            string[] parts = passwordHash.Split(PasswordHasherConstants.Separator);
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                PasswordHasherConstants.Iterations,
                PasswordHasherConstants.Algorithm,
                PasswordHasherConstants.HashSize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
