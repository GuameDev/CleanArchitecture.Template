using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<RefreshToken>> GetListBySpecificationAsync(ISpecification<RefreshToken> specification)
        {
            var query = SpecificationEvaluator<RefreshToken>.GetQuery(_context.RefreshTokens.AsQueryable(), specification);
            return await query.ToListAsync();
        }
        public void Update(RefreshToken entity)
        {
            _context.RefreshTokens.Update(entity);
        }

        public async Task<RefreshToken?> GetBySpecificationAsync(ISpecification<RefreshToken> specification)
        {
            var query = SpecificationEvaluator<RefreshToken>.GetQuery(_context.RefreshTokens.AsQueryable(), specification);
            return await query.FirstOrDefaultAsync();
        }

    }
}
