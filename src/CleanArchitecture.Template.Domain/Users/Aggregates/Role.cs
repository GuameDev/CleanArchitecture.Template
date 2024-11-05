using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates;
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

    public Result AddPermission(Permission permission)
    {
        if (_permissions.Any(p => p.Name == permission.Name))
            return Result.Failure(PermissionErrors.PermissionAlreadyAssigned);

        _permissions.Add(permission);
        return Result.Success();
    }

    public Result RemovePermission(Permission permission)
    {
        if (!_permissions.Any(p => p.Name == permission.Name))
            return Result.Failure(PermissionErrors.PermissionNotAssigned);

        _permissions.Remove(permission);
        return Result.Success();
    }
}
