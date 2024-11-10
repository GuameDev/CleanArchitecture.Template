using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Users
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Role?> GetByNameAsync(RoleName name)
        {
            return await _context.Roles
                .Where(x => x.RoleName.Equals(name))
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync();
        }
    }
}
