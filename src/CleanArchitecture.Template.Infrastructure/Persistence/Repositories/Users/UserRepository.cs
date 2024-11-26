using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Users
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
