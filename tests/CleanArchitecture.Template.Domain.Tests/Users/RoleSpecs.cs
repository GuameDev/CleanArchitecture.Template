using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;

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

            var permission = Permission.Create(PermissionType.Read, "Allows read access").Value;

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

            var permission = Permission.Create(PermissionType.Write, "Allows write access").Value;
            role.AddPermission(permission);

            // Act
            role.RemovePermission(permission);

            // Assert
            Assert.DoesNotContain(permission, role.Permissions);
        }

        [Fact]
        public void AddPermission_ShouldReturnFailure_WhenPermissionAlreadyExists()
        {
            // Arrange
            var roleName = RoleName.Admin;
            var role = Role.Create(Guid.NewGuid(), roleName).Value;

            var permission = Permission.Create(PermissionType.Read, "Allows read access").Value;
            role.AddPermission(permission);

            // Act
            var result = role.AddPermission(permission);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(PermissionErrors.PermissionAlreadyAssigned, result.Error);
        }
    }
}
