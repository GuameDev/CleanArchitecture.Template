using CleanArchitecture.Template.Domain.Base;

namespace CleanArchitecture.Template.Domain.Users.Aggregates
{
    public class RefreshToken : Entity
    {
        public int Id { get; set; }
        public required string Token { get; set; }
        public required DateTime ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsed { get; set; }
        public bool IsRevoked { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // Private constructor to enforce the factory method usage
        private RefreshToken() { }

        // Factory method to create a new RefreshToken
        public static RefreshToken Create(string token, DateTime expirationDate, User user)
        {
            return new RefreshToken
            {
                Token = token,
                ExpirationDate = expirationDate,
                CreatedAt = DateTime.UtcNow,
                User = user,
                UserId = user.Id,
                IsRevoked = false
            };
        }

        public void Revoke()
        {
            IsRevoked = true;
            LastUsed = DateTime.UtcNow;
        }
    }
}

