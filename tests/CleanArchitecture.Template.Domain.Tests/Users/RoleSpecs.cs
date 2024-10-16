﻿using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;

namespace CleanArchitecture.Template.Domain.Tests.Users
{
    public class RoleSpecs
    {
        [Fact]
        public void CreateRole_ShouldReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var roleName = RoleName.Admin;

            // Act
            var roleResult = Role.Create(Guid.NewGuid(), roleName);

            // Assert
            Assert.True(roleResult.IsSuccess);
            Assert.Equal(RoleName.Admin, roleResult.Value.RoleName);
        }

        [Fact]
        public void AddPermission_ShouldAddPermission_WhenPermissionIsValid()
        {
            // Arrange
            var roleName = RoleName.Admin;
            var role = Role.Create(Guid.NewGuid(), roleName).Value;

            var permission = Permission.Create("Read", "Allows read access").Value;

            // Act
            role.AddPermission(permission);

            // Assert
            Assert.Contains(permission, role.Permissions);
        }

        [Fact]
        public void RemovePermission_ShouldRemovePermission_WhenPermissionExists()
        {
            // Arrange
            var roleName = RoleName.User;
            var role = Role.Create(Guid.NewGuid(), roleName).Value;

            var permission = Permission.Create("Write", "Allows write access").Value;
            role.AddPermission(permission);

            // Act
            role.RemovePermission(permission);

            // Assert
            Assert.DoesNotContain(permission, role.Permissions);
        }

        [Fact]
        public void AddPermission_ShouldThrow_WhenPermissionAlreadyExists()
        {
            // Arrange
            var roleName = RoleName.Admin;
            var role = Role.Create(Guid.NewGuid(), roleName).Value;

            var permission = Permission.Create("Read", "Allows read access").Value;
            role.AddPermission(permission);

            var result = role.AddPermission(permission);

            // Act & Assert
            Assert.True(result.IsFailure);
            Assert.Equal(result.Error, PermissionErrors.PermissionAlreadyAssigned);
        }
    }
}
