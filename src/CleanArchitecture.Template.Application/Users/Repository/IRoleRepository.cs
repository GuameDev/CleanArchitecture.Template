using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameAsync(RoleName name);
    }
}
