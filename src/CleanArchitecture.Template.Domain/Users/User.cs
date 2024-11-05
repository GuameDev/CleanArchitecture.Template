using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        private readonly List<Role> _roles = new List<Role>();
        public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

        public required Guid Id { get; init; }
        public required Username Username { get; init; }
        public required Email Email { get; init; }
        public required FullName FullName { get; init; }
        public required string PasswordHash { get; init; }
        public bool IsActive { get; private set; } = true;


        private User() { }

        private User(Guid id, Username username, Email email, FullName fullName, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            FullName = fullName;
            PasswordHash = passwordHash;
            IsActive = true;
        }

        public static Result<User> Create(string username, string email, string passwordHash, string firstName, string lastName1, string? lastName2)
        {
            var usernameResult = Username.Create(username);
            var emailResult = Email.Create(email);
            var fullNameResult = FullName.Create(firstName, lastName1, lastName2);

            if (usernameResult.IsFailure || emailResult.IsFailure || fullNameResult.IsFailure)
                return Result.Failure<User>(UserErrors.InvalidUserDetails);

            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<User>(UserErrors.InvalidPasswordHash);

            return Result.Success(new User()
            {
                Id = Guid.NewGuid(),
                Username = usernameResult.Value,
                Email = emailResult.Value,
                FullName = fullNameResult.Value,
                PasswordHash = passwordHash
            });
        }

        public static Result<User> Create(Username username, Email email, FullName fullName, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<User>(UserErrors.InvalidPasswordHash);

            return Result.Success(new User()
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                FullName = fullName,
                PasswordHash = passwordHash
            });
        }
        public bool HasRole(RoleName roleName) => Roles.Any(role => role.RoleName == roleName);
        public bool HasPermission(PermissionType permissionType) => Roles.Any(role => role.Permissions.Any(p => p.Type == permissionType));

        public Result AddRole(Role role)
        {
            if (_roles.Any(r => r.RoleName == role.RoleName))
                return Result.Failure(RoleErrors.RoleAlreadyAssigned);

            _roles.Add(role);
            return Result.Success();
        }

        public Result RemoveRole(Role role)
        {
            if (!_roles.Any(r => r.RoleName == role.RoleName))
                return Result.Failure(RoleErrors.RoleNotAssigned);

            _roles.Remove(role);

            // Remove associated permissions not provided by other roles
            var permissionsFromRole = role.Permissions.ToList();
            foreach (var permission in permissionsFromRole)
            {
                if (!HasPermission(permission.Type))
                {
                    RemovePermission(permission);
                }
            }

            return Result.Success();
        }

        private void RemovePermission(Permission permission)
        {
            foreach (var role in _roles)
            {
                role.RemovePermission(permission);
            }
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;
    }
}
