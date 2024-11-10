using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Commands.RefreshTokens;
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
            var mockAuthTokenService = new Mock<IAuthTokenService>();
            var handler = new RefreshTokenHandler(mockUnitOfWork.Object, mockAuthTokenService.Object);

            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;
            var existingRefreshToken = RefreshToken.Create("validTokenWithrightLength1234567", DateTime.UtcNow.AddDays(1), user).Value;
            var newRefreshTokenResponse = new LoginUserTokenResponse("validTokenWithrightLength1234567", DateTime.UtcNow.AddDays(7));
            var newAccessTokenResponse = new LoginUserTokenResponse("newAccessToken", DateTime.UtcNow.AddMinutes(30));

            // Mock existing refresh token retrieval
            mockUnitOfWork.Setup(uow => uow.RefreshTokenRepository.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                          .ReturnsAsync(existingRefreshToken);

            // Mock token generation
            mockAuthTokenService.Setup(auth => auth.GenerateAccessToken(user)).Returns(newAccessTokenResponse);
            mockAuthTokenService.Setup(auth => auth.GenerateRefreshToken()).Returns(newRefreshTokenResponse);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand("existingToken"), CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(newAccessTokenResponse.Token, result.Value.AccessToken.Token);
            Assert.Equal(newRefreshTokenResponse.Token, result.Value.RefreshToken.Token);

            // Verify refresh token update and new token creation
            mockUnitOfWork.Verify(uow => uow.RefreshTokenRepository.Update(existingRefreshToken), Times.Once);
            mockUnitOfWork.Verify(uow => uow.RefreshTokenRepository.AddAsync(It.IsAny<RefreshToken>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task RefreshToken_ShouldReturnFailure_WhenRefreshTokenIsExpired()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockAuthTokenService = new Mock<IAuthTokenService>();
            var handler = new RefreshTokenHandler(mockUnitOfWork.Object, mockAuthTokenService.Object);

            var user = User.Create("johndoe", "johndoe@example.com", "hashedPassword", "John", "Doe", null).Value;
            var expiredRefreshToken = RefreshToken.Create("expiredTokenWithrightLength12345", DateTime.UtcNow.AddDays(-1), user).Value;

            // Mock expired token retrieval
            mockUnitOfWork.Setup(uow => uow.RefreshTokenRepository.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                          .ReturnsAsync(expiredRefreshToken);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand("expiredToken"), CancellationToken.None);

            // Assert that it failed and returned the expected error
            Assert.False(result.IsSuccess, "Expected the refresh token to be expired and thus fail.");
            Assert.Equal(RefreshTokenErrors.TokenInvalidOrExpired, result.Error);

            // Ensure no add or commit actions were triggered due to expiration
            mockUnitOfWork.Verify(uow => uow.RefreshTokenRepository.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }



        [Fact]
        public async Task RefreshToken_ShouldReturnFailure_WhenRefreshTokenIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockAuthTokenService = new Mock<IAuthTokenService>();
            var handler = new RefreshTokenHandler(mockUnitOfWork.Object, mockAuthTokenService.Object);

            // Mock invalid token retrieval (returns null)
            mockUnitOfWork.Setup(uow => uow.RefreshTokenRepository.GetBySpecificationAsync(It.IsAny<RefreshTokenByTokenSpecification>()))
                          .ReturnsAsync((RefreshToken?)null);

            // Act
            var result = await handler.Handle(new RefreshTokenCommand("invalidToken"), CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(RefreshTokenErrors.TokenInvalidOrExpired, result.Error);

            // Verify no database operations occurred
            mockUnitOfWork.Verify(uow => uow.RefreshTokenRepository.AddAsync(It.IsAny<RefreshToken>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
