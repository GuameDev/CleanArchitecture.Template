using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Domain.Users;
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

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Where(x => x.Email.Value.Equals(email))
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                 .Where(x => x.Username.Value.Equals(username))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Exist(string username, string email)
        {
            return await _context.Users
                 .AnyAsync(x =>
                    x.Username.Value.Equals(username)
                 || x.Email.Value.Equals(email));

        }
    }
}
