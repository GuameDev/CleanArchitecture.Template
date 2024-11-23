using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Application.Users.Specifications.UserSpecifications;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
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
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(
                mockUnitOfWork.Object,
                mockUserRepository.Object,
                mockRefreshTokenRepository.Object,
                mockPasswordHasher.Object,
                mockAuthTokenService.Object
            );

            var request = new LoginUserCommand("johndoe@example.com", "StrongPass123!");
            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            mockUserRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                .ReturnsAsync(user);

            mockPasswordHasher
                .Setup(ph => ph.Verify(request.Password, user.PasswordHash))
                .Returns(true);

            var accessTokenResponse = new LoginUserTokenResponse("validAccessToken", DateTime.UtcNow.AddMinutes(30));
            mockAuthTokenService
                .Setup(auth => auth.GenerateAccessToken(user))
                .Returns(accessTokenResponse);

            var refreshTokenBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(refreshTokenBytes);
            }
            var refreshTokenString = Convert.ToBase64String(refreshTokenBytes);

            var refreshTokenResponse = new LoginUserTokenResponse(refreshTokenString, DateTime.UtcNow.AddDays(7));
            mockAuthTokenService
                .Setup(auth => auth.GenerateRefreshToken())
                .Returns(refreshTokenResponse);

            mockRefreshTokenRepository
                .Setup(repo => repo.AddAsync(It.IsAny<RefreshToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("validAccessToken", result.Value.AccessToken.Token);
            Assert.Equal(refreshTokenString, result.Value.RefreshToken.Token);

            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task LoginUser_ShouldReturnFailure_WhenUserNotFound()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(
                _fixture.CreateMockUnitOfWork().Object,
                mockUserRepository.Object,
                mockRefreshTokenRepository.Object,
                mockPasswordHasher.Object,
                mockAuthTokenService.Object
            );

            var request = new LoginUserCommand("nonexistent@example.com", "StrongPass123!");

            mockUserRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
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
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(
                _fixture.CreateMockUnitOfWork().Object,
                mockUserRepository.Object,
                mockRefreshTokenRepository.Object,
                mockPasswordHasher.Object,
                mockAuthTokenService.Object
            );

            var request = new LoginUserCommand("johndoe@example.com", "WrongPass123!");
            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            mockUserRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                .ReturnsAsync(user);

            mockPasswordHasher
                .Setup(ph => ph.Verify(request.Password, user.PasswordHash))
                .Returns(false);

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
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new LoginUserHandler(
                _fixture.CreateMockUnitOfWork().Object,
                mockUserRepository.Object,
                mockRefreshTokenRepository.Object,
                mockPasswordHasher.Object,
                mockAuthTokenService.Object
            );

            var request = new LoginUserCommand("johndoe@example.com", "StrongPass123!");
            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            mockUserRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<UserByEmailOrUsernameSpecification>()))
                .ReturnsAsync(user);

            mockPasswordHasher
                .Setup(ph => ph.Verify(request.Password, user.PasswordHash))
                .Returns(true);

            var accessTokenResponse = new LoginUserTokenResponse("validAccessToken", DateTime.UtcNow.AddMinutes(30));
            mockAuthTokenService
                .Setup(auth => auth.GenerateAccessToken(user))
                .Returns(accessTokenResponse);

            var invalidRefreshTokenResponse = new LoginUserTokenResponse("short", DateTime.UtcNow.AddDays(7));
            mockAuthTokenService
                .Setup(auth => auth.GenerateRefreshToken())
                .Returns(invalidRefreshTokenResponse);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RefreshTokenErrors.TokenMinLength, result.Error);
            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
