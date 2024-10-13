using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Errors;

namespace CleanArchitecture.Template.Domain.Tests.Users
{
    public class PermissionSpecs
    {
        [Fact]
        public void CreatePermission_ShouldReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var permissionName = "Read";
            var description = "Allows reading data";

            // Act
            var permissionResult = Permission.Create(permissionName, description);

            // Assert
            Assert.True(permissionResult.IsSuccess);
            Assert.Equal(permissionName, permissionResult.Value.Name);
            Assert.Equal(description, permissionResult.Value.Description);
        }

        [Fact]
        public void CreatePermission_ShouldReturnFailure_WhenNameIsInvalid()
        {
            // Arrange
            var description = "Allows reading data";

            // Act
            var permissionResult = Permission.Create("", description);

            // Assert
            Assert.False(permissionResult.IsSuccess);
            Assert.Equal(PermissionErrors.InvalidName, permissionResult.Error);
        }

        [Fact]
        public void CreatePermission_ShouldReturnFailure_WhenDescriptionIsInvalid()
        {
            // Arrange
            var permissionName = "Write";

            // Act
            var permissionResult = Permission.Create(permissionName, "");

            // Assert
            Assert.False(permissionResult.IsSuccess);
            Assert.Equal(PermissionErrors.InvalidDescription, permissionResult.Error);
        }
    }
}
