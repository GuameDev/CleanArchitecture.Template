using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.Specifications;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.Users.Commands
{
    public class LoginUserSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly MediatorIntegrationSetup _fixture;

        public LoginUserSpecs(MediatorIntegrationSetup fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task LoginUser_ShouldReturnSuccess_WhenCredentialsAreValid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object, mockAuthTokenService.Object);

            var request = new LoginUserCommand("johndoe@example.com", "StrongPass123!");
            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Mock repository behavior
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                          .ReturnsAsync(user);

            // Mock password verification
            mockPasswordHasher.Setup(ph => ph.Verify(request.Password, user.PasswordHash)).Returns(true);

            // Mock token generation
            var tokenResponse = new LoginUserResponse("validToken", DateTime.UtcNow.AddHours(1));
            mockAuthTokenService.Setup(auth => auth.GenerateToken(user)).Returns(tokenResponse);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("validToken", result.Value.Token);
        }

        [Fact]
        public async Task LoginUser_ShouldReturnFailure_WhenUserNotFound()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object, mockAuthTokenService.Object);
            var request = new LoginUserCommand("nonexistent@example.com", "StrongPass123!");

            // Mock repository behavior to return null (user not found)
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                          .ReturnsAsync((User?)null);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.UserNotFound, result.Error);
        }

        [Fact]
        public async Task LoginUser_ShouldReturnFailure_WhenPasswordIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object, mockAuthTokenService.Object);
            var request = new LoginUserCommand("johndoe@example.com", "WrongPass123!");

            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Mock repository to return a valid user
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                          .ReturnsAsync(user);

            // Mock password verification to fail
            mockPasswordHasher.Setup(ph => ph.Verify(request.Password, user.PasswordHash)).Returns(false);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.UserInvalidCredentials, result.Error);
        }
    }
}
