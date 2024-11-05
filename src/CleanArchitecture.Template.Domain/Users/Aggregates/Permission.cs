using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates;
public class Permission : Entity
{
    private readonly List<Role> _roles = new List<Role>();
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public required Guid Id { get; init; }
    public required PermissionType Type { get; init; }
    public required string Description { get; init; }

    private Permission() { }

    private Permission(PermissionType type, string description)
    {
        this.Type = type;
        Description = description;
    }

    // Factory Method with validation
    public static Result<Permission> Create(PermissionType name, string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Permission>(PermissionErrors.InvalidDescription);

        return Result.Success(new Permission()
        {
            Id = Guid.NewGuid(),
            Description = description,
            Type = name
        });
    }
}
