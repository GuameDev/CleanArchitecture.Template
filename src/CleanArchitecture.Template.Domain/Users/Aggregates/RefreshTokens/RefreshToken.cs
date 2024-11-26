using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens
{
    public class RefreshToken : Entity
    {
        public required string Token { get; set; }
        public required DateTime ExpirationDate { get; set; }
        public DateTime? LastUsed { get; set; }
        public bool IsRevoked { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // Private constructor to enforce the factory method usage
        private RefreshToken() { }

        // Factory method to create a new RefreshToken
        public static Result<RefreshToken> Create(string token, DateTime expirationDate, User user)
        {
            if (string.IsNullOrWhiteSpace(token) || token.Length < RefreshTokenConstants.TokenMinLength)
            {
                return Result.Failure<RefreshToken>(RefreshTokenErrors.TokenMinLength);
            }
            return Result.Success(new RefreshToken
            {
                Token = token,
                ExpirationDate = expirationDate,
                User = user,
                CreatedDate = DateTime.UtcNow,
                UserId = user.Id,
                IsRevoked = false
            });
        }

        public void Revoke()
        {
            IsRevoked = true;
            LastUsed = DateTime.UtcNow;
        }
    }
}

