using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates
{
    public class Role : Entity
    {
        private readonly List<Permission> _permissions = new List<Permission>();
        public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();
        public Guid Id { get; private set; }
        public RoleName RoleName { get; private set; }

        private Role() { } // For EF

        private Role(Guid id, RoleName roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        // Factory Method
        public static Result<Role> Create(Guid id, RoleName roleName)
        {
            return Result.Success(new Role(id, roleName));
        }

        public void AddPermission(Permission permission)
        {
            if (_permissions.Any(p => p.Name == permission.Name))
                throw new InvalidOperationException("Role already has this permission.");

            _permissions.Add(permission);
        }

        public void RemovePermission(Permission permission)
        {
            _permissions.Remove(permission);
        }
    }
}
