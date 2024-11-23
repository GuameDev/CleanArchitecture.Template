using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Commands.RefreshTokens;
using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.Users.Commands
{
    public class RefreshTokenHandlerSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly MediatorIntegrationSetup _fixture;

        public RefreshTokenHandlerSpecs(MediatorIntegrationSetup fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task RefreshToken_ShouldReturnNewTokens_WhenRefreshTokenIsValid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new RefreshTokenHandler(
                mockUnitOfWork.Object,
                mockAuthTokenService.Object,
                mockRefreshTokenRepository.Object
            );

            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;

            // Ensure a valid token that passes validation
            var validToken = "validToken32bitsabcdefghijklmnop"; // Ensure this token meets length or format requirements
            var expirationDate = DateTime.UtcNow.AddDays(1); // Ensure this date is in the future
            var existingRefreshTokenResult = RefreshToken.Create(validToken, expirationDate, user);

            // Throw an exception if token creation fails during the test setup
            if (existingRefreshTokenResult.IsFailure)
            {
                throw new InvalidOperationException($"Test setup failed: {existingRefreshTokenResult.Error}");
            }

            var existingRefreshToken = existingRefreshTokenResult.Value;

            // Mock responses for the handler
            var newRefreshTokenResponse = new LoginUserTokenResponse("newValidToken32bitsabcdefghijklm", DateTime.UtcNow.AddDays(7));
            var newAccessTokenResponse = new LoginUserTokenResponse("newAccessToken", DateTime.UtcNow.AddMinutes(30));

            // Mock existing refresh token retrieval
            mockRefreshTokenRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                .ReturnsAsync(existingRefreshToken);

            // Mock token generation
            mockAuthTokenService
                .Setup(auth => auth.GenerateAccessToken(user))
                .Returns(newAccessTokenResponse);
            mockAuthTokenService
                .Setup(auth => auth.GenerateRefreshToken())
                .Returns(newRefreshTokenResponse);

            // Mock repository and unit of work behavior
            mockRefreshTokenRepository
                .Setup(repo => repo.AddAsync(It.IsAny<RefreshToken>()))
                .Returns(Task.CompletedTask);

            mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand(validToken), CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(newAccessTokenResponse.Token, result.Value.AccessToken.Token);
            Assert.Equal(newRefreshTokenResponse.Token, result.Value.RefreshToken.Token);

            // Verify repository interactions
            mockRefreshTokenRepository.Verify(repo => repo.Update(existingRefreshToken), Times.Once);
            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }



        [Fact]
        public async Task RefreshToken_ShouldReturnFailure_WhenRefreshTokenIsExpired()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new RefreshTokenHandler(
                mockUnitOfWork.Object,
                mockAuthTokenService.Object,
                mockRefreshTokenRepository.Object
            );

            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;
            var expiredRefreshToken = RefreshToken.Create("expiredTokenWithRightLength12345", DateTime.UtcNow.AddDays(-1), user).Value;

            // Mock expired token retrieval
            mockRefreshTokenRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                .ReturnsAsync(expiredRefreshToken);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand("expiredToken"), CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RefreshTokenErrors.TokenInvalidOrExpired, result.Error);

            // Verify no database operations occurred due to expiration
            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RefreshToken_ShouldReturnFailure_WhenRefreshTokenIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockRefreshTokenRepository = new Mock<IRefreshTokenRepository>();
            var mockAuthTokenService = new Mock<IAuthTokenService>();

            var handler = new RefreshTokenHandler(
                mockUnitOfWork.Object,
                mockAuthTokenService.Object,
                mockRefreshTokenRepository.Object
            );

            // Mock invalid token retrieval (returns null)
            mockRefreshTokenRepository
                .Setup(repo => repo.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                .ReturnsAsync((RefreshToken?)null);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand("invalidToken"), CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RefreshTokenErrors.TokenInvalidOrExpired, result.Error);

            // Verify no database operations occurred
            mockRefreshTokenRepository.Verify(repo => repo.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
