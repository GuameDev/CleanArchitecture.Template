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
        public void Create_ShouldReturnFailure_WhenEmailExceedsMaxLength()
        {
            // Arrange valid email at max length
            var maxLengthEmail = new string('a', EmailConstants.MaxLength - "@example.com".Length) + "@example.com";

            // Act
            var validResult = Email.Create(maxLengthEmail);

            // Assert
            Assert.True(validResult.IsSuccess); // Should pass for max length

            // Arrange email exceeding max length
            var tooLongEmail = new string('a', EmailConstants.MaxLength - "@example.com".Length + 1) + "@example.com";

            // Act
            var invalidResult = Email.Create(tooLongEmail);

            // Assert
            Assert.False(invalidResult.IsSuccess); // Should fail for exceeding max length
            Assert.Equal(EmailErrors.MaxLength, invalidResult.Error);
        }


        [Fact]
        public void Create_ShouldReturnFailure_WhenEmailHasConsecutiveDots()
        {
            // Arrange
            var email = "test..email@example.com";

            // Act
            var result = Email.Create(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(EmailErrors.InvalidEmailFormat, result.Error);
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
    }
}
