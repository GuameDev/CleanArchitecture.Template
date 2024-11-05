using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;

namespace CleanArchitecture.Template.Domain.Tests.Users
{
    public class PermissionSpecs
    {
        [Fact]
        public void CreatePermission_ShouldReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var permissionType = PermissionType.Read;
            var description = "Allows reading data";

            // Act
            var permissionResult = Permission.Create(permissionType, description);

            // Assert
            Assert.True(permissionResult.IsSuccess);
            Assert.Equal(permissionType, permissionResult.Value.Type);
            Assert.Equal(description, permissionResult.Value.Description);
        }

        [Fact]
        public void CreatePermission_ShouldReturnFailure_WhenDescriptionIsInvalid()
        {
            // Arrange
            var permissionType = PermissionType.Write;

            // Act
            var permissionResult = Permission.Create(permissionType, "");

            // Assert
            Assert.False(permissionResult.IsSuccess);
            Assert.Equal(PermissionErrors.InvalidDescription, permissionResult.Error);
        }
    }
}
