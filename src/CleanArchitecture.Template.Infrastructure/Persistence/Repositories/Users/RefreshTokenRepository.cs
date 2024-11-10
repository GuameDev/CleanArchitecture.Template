using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Domain.Users.Aggregates;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Users
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken entity)
        {
            await _context.RefreshTokens.AddAsync(entity);
        }
    }
}
