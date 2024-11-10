using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> ExistAsync(ISpecification<User> specification)
        {
            var query = SpecificationEvaluator<User>.GetQuery(_context.Users.AsQueryable(), specification);
            return await query.AnyAsync();
        }

        public async Task<User?> GetBySpecificationAsync(ISpecification<User> specification)
        {
            var query = SpecificationEvaluator<User>.GetQuery(_context.Users.AsQueryable(), specification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetListBySpecificationAsync(ISpecification<User> specification)
        {
            var query = SpecificationEvaluator<User>.GetQuery(_context.Users.AsQueryable(), specification);
            return await query.ToListAsync();
        }
    }
}
