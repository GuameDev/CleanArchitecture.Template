using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates;
public class Permission : Entity
{
    private readonly List<Role> _roles = new List<Role>();
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Permission() { } // For EF

    private Permission(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Factory Method with validation
    public static Result<Permission> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Permission>(PermissionErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Permission>(PermissionErrors.InvalidDescription);

        return Result.Success(new Permission(name, description));
    }
}
