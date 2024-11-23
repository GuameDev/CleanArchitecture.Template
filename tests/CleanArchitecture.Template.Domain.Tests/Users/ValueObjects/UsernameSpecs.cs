using CleanArchitecture.Template.Domain.Users.ValueObjects.Usernames;

namespace CleanArchitecture.Template.Domain.Tests.Users.ValueObjects
{
    public class UsernameSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenUsernameIsValid()
        {
            // Arrange
            var validUsername = "ValidUser";

            // Act
            var result = Username.Create(validUsername);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(validUsername, result.Value.Value);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenUsernameIsEmpty()
        {
            // Arrange
            var invalidUsername = "";

            // Act
            var result = Username.Create(invalidUsername);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UsernameErrors.EmptyUsername, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenUsernameIsTooShort()
        {
            // Arrange
            var shortUsername = "ab"; // Less than 3 characters

            // Act
            var result = Username.Create(shortUsername);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UsernameErrors.InvalidUsernameLength, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenUsernameIsTooLong()
        {
            // Arrange
            var longUsername = new string('a', 51); // More than 50 characters

            // Act
            var result = Username.Create(longUsername);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UsernameErrors.InvalidUsernameLength, result.Error);
        }
    }
}
