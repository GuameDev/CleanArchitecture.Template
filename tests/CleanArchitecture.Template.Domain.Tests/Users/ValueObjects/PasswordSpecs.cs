using CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords;

namespace CleanArchitecture.Template.Domain.Tests.Users.ValueObjects
{
    public class PasswordSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenPasswordIsValid()
        {
            // Arrange
            var password = "StrongPass123!";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(password, result.Value.Value);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordIsEmpty()
        {
            // Arrange
            var password = "";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.EmptyPassword.Description, result.Error.Description);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordIsTooShort()
        {
            // Arrange
            var password = "Short1!";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MinLengthPassword.Description, result.Error.Description);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordMissingUppercase()
        {
            // Arrange
            var password = "lowercase123!";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MissingUppercase.Description, result.Error.Description);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordMissingLowercase()
        {
            // Arrange
            var password = "ALLUPPERCASE123!";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MissingLowercase.Description, result.Error.Description);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordMissingDigit()
        {
            // Arrange
            var password = "NoDigitsHere!";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MissingDigit.Description, result.Error.Description);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenPasswordMissingSpecialCharacter()
        {
            // Arrange
            var password = "NoSpecial123";

            // Act
            var result = Password.Create(password);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MissingSpecialCharacter.Description, result.Error.Description);
        }
    }
}
