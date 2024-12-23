﻿using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Emails;
using CleanArchitecture.Template.Domain.Users.ValueObjects.FullNames;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Usernames;

namespace CleanArchitecture.Template.Domain.Tests.Users
{
    public class UserSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var username = "validUser";
            var email = "valid@example.com";
            var firstName = "John";
            var lastName1 = "Doe";
            var passwordHash = "hashedPassword";

            // Act
            var result = User.Create(username, email, passwordHash, firstName, lastName1, null);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(username, result.Value.Username.Value);
            Assert.Equal(email, result.Value.Email.Value);
            Assert.Equal(firstName, result.Value.FullName.FirstName);
            Assert.Equal(lastName1, result.Value.FullName.LastName1);
            Assert.Equal(passwordHash, result.Value.PasswordHash);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenUsernameIsInvalid()
        {
            // Arrange
            var email = "valid@example.com";
            var firstName = "John";
            var lastName1 = "Doe";
            var passwordHash = "hashedPassword";

            // Act
            var result = User.Create("", email, passwordHash, firstName, lastName1, null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UsernameErrors.EmptyUsername, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenEmailIsInvalid()
        {
            // Arrange
            var username = "validUser";
            var invalidEmail = "invalid-email";
            var firstName = "John";
            var lastName1 = "Doe";
            var passwordHash = "hashedPassword";

            // Act
            var result = User.Create(username, invalidEmail, passwordHash, firstName, lastName1, null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(EmailErrors.InvalidEmailFormat, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenFullNameIsInvalid()
        {
            // Arrange
            var username = "validUser";
            var email = "valid@example.com";
            var firstName = "";
            var lastName1 = "";
            var passwordHash = "hashedPassword";

            // Act
            var result = User.Create(username, email, passwordHash, firstName, lastName1, null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(FullNameErrors.InvalidFullName, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordHashIsEmpty()
        {
            // Arrange
            var username = "validUser";
            var email = "valid@example.com";
            var firstName = "John";
            var lastName1 = "Doe";

            // Act
            var result = User.Create(username, email, "", firstName, lastName1, null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.EmptyPassword, result.Error);
        }

        [Fact]
        public void AddRole_ShouldReturnSuccess_WhenRoleIsNotAlreadyAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;

            // Act
            var result = user.AddRole(role);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Contains(role, user.Roles);
        }

        [Fact]
        public void AddRole_ShouldReturnFailure_WhenRoleIsAlreadyAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;

            // Act
            user.AddRole(role); // First time
            var result = user.AddRole(role); // Second time should fail

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RoleErrors.RoleAlreadyAssigned, result.Error);
        }

        [Fact]
        public void RemoveRole_ShouldReturnSuccess_WhenRoleIsAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;
            user.AddRole(role); // Assign role first

            // Act
            var result = user.RemoveRole(role);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.DoesNotContain(role, user.Roles);
        }

        [Fact]
        public void RemoveRole_ShouldReturnFailure_WhenRoleIsNotAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;

            // Act
            var result = user.RemoveRole(role);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RoleErrors.RoleNotAssigned, result.Error);
        }

        [Fact]
        public void HasRole_ShouldReturnTrue_WhenRoleIsAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;
            user.AddRole(role);

            // Act
            var result = user.HasRole(RoleName.Admin);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasRole_ShouldReturnFalse_WhenRoleIsNotAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Act
            var result = user.HasRole(RoleName.Admin);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasPermission_ShouldReturnTrue_WhenPermissionIsAssignedThroughRole()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;
            var role = Role.Create(Guid.NewGuid(), RoleName.Admin).Value;
            var permission = Permission.Create(PermissionType.Read, "Allows read access").Value;
            role.AddPermission(permission);
            user.AddRole(role);

            // Act
            var result = user.HasPermission(PermissionType.Read);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasPermission_ShouldReturnFalse_WhenPermissionIsNotAssigned()
        {
            // Arrange
            var user = User.Create("validUser", "valid@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Act
            var result = user.HasPermission(PermissionType.Write);

            // Assert
            Assert.False(result);
        }
    }
}
