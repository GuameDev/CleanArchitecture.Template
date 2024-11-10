using CleanArchitecture.Template.Domain.Users.ValueObjects.Emails;

namespace CleanArchitecture.Template.Domain.Tests.Users.ValueObjects
{
    public class EmailSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenEmailIsValid()
        {
            // Arrange
            var email = "test@example.com";

            // Act
            var result = Email.Create(email);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(email, result.Value.Value);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenEmailIsEmpty()
        {
            // Arrange
            var email = "";

            // Act
            var result = Email.Create(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(EmailErrors.InvalidEmail, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenEmailFormatIsInvalid()
        {
            // Arrange
            var email = "invalidemail@com";

            // Act
            var result = Email.Create(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(EmailErrors.InvalidEmailFormat, result.Error);
        }

        [Theory]
        [InlineData("email@domain.com")]
        [InlineData("firstname.lastname@domain.com")]
        [InlineData("email@subdomain.domain.com")]
        [InlineData("email@domain.co.jp")]
        [InlineData("firstname+lastname@domain.com")]
        public void Create_ShouldReturnSuccess_ForVariousValidEmails(string validEmail)
        {
            // Act
            var result = Email.Create(validEmail);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(validEmail, result.Value.Value);
        }

        [Theory]
        [InlineData("plainaddress")]
        [InlineData("@missingusername.com")]
        [InlineData("username@.com")]
        [InlineData("username@domain..com")]
        public void Create_ShouldReturnFailure_ForVariousInvalidEmails(string invalidEmail)
        {
            // Act
            var result = Email.Create(invalidEmail);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(EmailErrors.InvalidEmailFormat, result.Error);
        }
    }
}
