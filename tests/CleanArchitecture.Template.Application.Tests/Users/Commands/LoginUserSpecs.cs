using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications;
using CleanArchitecture.Template.Domain.Users.Specifications;
using Moq;
using System.Security.Cryptography;

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
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();

            var handler = new LoginUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object, mockAuthTokenService.Object);

            var request = new LoginUserCommand("johndoe@example.com", "StrongPass123!");
            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Mock repository behavior
            mockUnitOfWork.Setup(uow => uow.UserRepository.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                          .ReturnsAsync(user);

            // Mock password verification
            mockPasswordHasher.Setup(ph => ph.Verify(request.Password, user.PasswordHash)).Returns(true);

            // Mock access token generation
            var accessTokenResponse = new LoginUserTokenResponse("validAccessToken", DateTime.UtcNow.AddMinutes(30));
            mockAuthTokenService.Setup(auth => auth.GenerateAccessToken(user)).Returns(accessTokenResponse);

            // Generate a 32-byte base64 string for the refresh token
            var refreshTokenBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(refreshTokenBytes);
            }
            var refreshTokenString = Convert.ToBase64String(refreshTokenBytes);

            // Mock refresh token generation
            var refreshTokenResponse = new LoginUserTokenResponse(refreshTokenString, DateTime.UtcNow.AddDays(7));
            mockAuthTokenService.Setup(auth => auth.GenerateRefreshToken()).Returns(refreshTokenResponse);

            // Mock the refresh token repository AddAsync
            mockRefreshTokenRepository.Setup(repo => repo.AddAsync(It.IsAny<RefreshToken>()))
                                      .Returns(Task.CompletedTask);
            mockUnitOfWork.Setup(uow => uow.RefreshTokenRepository).Returns(mockRefreshTokenRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("validAccessToken", result.Value.AccessToken.Token);
            Assert.Equal(refreshTokenString, result.Value.RefreshToken.Token);

            // Verify that the refresh token is saved to the repository
            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
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

        [Fact]
        public async Task LoginUser_ShouldReturnFailure_WhenRefreshTokenCreationFails()
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

            // Mock access token generation
            var accessTokenResponse = new LoginUserTokenResponse("validAccessToken", DateTime.UtcNow.AddMinutes(30));
            mockAuthTokenService.Setup(auth => auth.GenerateAccessToken(user)).Returns(accessTokenResponse);

            // Mock refresh token generation with an invalid token (e.g., too short)
            var invalidRefreshTokenResponse = new LoginUserTokenResponse("short", DateTime.UtcNow.AddDays(7));
            mockAuthTokenService.Setup(auth => auth.GenerateRefreshToken()).Returns(invalidRefreshTokenResponse);

            // Mock the refresh token repository behavior for active tokens
            var emptyTokenList = new List<RefreshToken>();
            mockUnitOfWork.Setup(uow => uow.RefreshTokenRepository.GetListBySpecificationAsync(It.IsAny<ActiveRefreshTokensByUserIdSpecification>()))
                                      .ReturnsAsync(emptyTokenList);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RefreshTokenErrors.TokenMinLength, result.Error);

            // Verify that no refresh token is saved to the repository
            mockUnitOfWork.Verify(uow => uow.RefreshTokenRepository.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
