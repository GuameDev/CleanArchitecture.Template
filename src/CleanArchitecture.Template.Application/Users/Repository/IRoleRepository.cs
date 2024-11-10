using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameAsync(RoleName name);
    }
}
