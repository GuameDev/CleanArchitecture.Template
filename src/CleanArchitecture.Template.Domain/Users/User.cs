using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.Users.Aggregates
{
    public class User : Entity, IAggregateRoot
    {
        private readonly List<Role> _roles = new List<Role>();
        public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

        public Guid Id { get; private set; }
        public Username Username { get; private set; }
        public Email Email { get; private set; }
        public FullName FullName { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }

        private User() { } // For EF

        private User(Guid id, Username username, Email email, FullName fullName, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            FullName = fullName;
            PasswordHash = passwordHash;
            IsActive = true;
        }

        // Factory Method
        public static Result<User> Create(string username, string email, string passwordHash, string firstName, string lastName1, string? lastName2)
        {
            var usernameResult = Username.Create(username);
            var emailResult = Email.Create(email);
            var fullNameResult = FullName.Create(firstName, lastName1, lastName2);

            if (usernameResult.IsFailure || emailResult.IsFailure || fullNameResult.IsFailure)
                return Result.Failure<User>(UserErrors.InvalidUserDetails);

            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<User>(UserErrors.InvalidPasswordHash);

            return Result.Success(new User(Guid.NewGuid(), usernameResult.Value, emailResult.Value, fullNameResult.Value, passwordHash));
        }
        public static Result<User> Create(Username username, Email email, FullName fullname, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<User>(UserErrors.InvalidPasswordHash);

            return Result.Success(new User(Guid.NewGuid(), username, email, fullname, passwordHash));
        }

        // Role management
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
            return Result.Success();
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;
    }
}
