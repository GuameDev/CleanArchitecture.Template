using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Services;
using CleanArchitecture.Template.Domain.Users.Aggregates; // Correct namespace for Role
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Domain.Users.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.Users.Commands
{
    public class RegisterUserSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly MediatorIntegrationSetup _fixture;

        public RegisterUserSpecs(MediatorIntegrationSetup fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, null!);
            var handler = new RegisterUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object);

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            // Mock repository checks
            mockUnitOfWork.Setup(uow => uow.UserRepository.Exist(It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(false);

            // Mock password hashing
            mockPasswordHasher.Setup(ph => ph.Hash(It.IsAny<string>()))
                              .Returns("hashedpassword");

            // Mock role retrieval using Role.Create
            mockUnitOfWork.Setup(uow => uow.RoleRepository.GetByNameAsync(RoleName.User))
                          .ReturnsAsync(Role.Create(Guid.NewGuid(), RoleName.User).Value);

            // Mock repository save actions
            mockUnitOfWork.Setup(uow => uow.UserRepository.AddUserAsync(It.IsAny<Domain.Users.User>()))
                          .Returns(Task.CompletedTask);
            mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                          .ReturnsAsync(1);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            mockUnitOfWork.Verify(uow => uow.UserRepository.AddUserAsync(It.IsAny<Domain.Users.User>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenUserAlreadyExists()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object);

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            // Mock repository checks - user already exists
            mockUnitOfWork.Setup(uow => uow.UserRepository.Exist(It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(true); // Simulate user already existing

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.UserAlreadyExist, result.Error);
            mockUnitOfWork.Verify(uow => uow.UserRepository.AddUserAsync(It.IsAny<Domain.Users.User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenPasswordIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object);

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "weak" // Invalid password
            );

            // Mock repository checks
            mockUnitOfWork.Setup(uow => uow.UserRepository.Exist(It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(false);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MinLengthPassword, result.Error);
            mockUnitOfWork.Verify(uow => uow.UserRepository.AddUserAsync(It.IsAny<Domain.Users.User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenDefaultRoleNotFound()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(mockUnitOfWork.Object, mockPasswordHasher.Object);

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            // Mock repository checks
            mockUnitOfWork.Setup(uow => uow.UserRepository.Exist(It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(false);

            // Mock password hashing
            mockPasswordHasher.Setup(ph => ph.Hash(It.IsAny<string>()))
                              .Returns("hashedpassword");

            // Simulate default role not found
            mockUnitOfWork.Setup(uow => uow.RoleRepository.GetByNameAsync(RoleName.User))
                      .ReturnsAsync((Role?)null);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.DefaultRoleNotFound, result.Error);
            mockUnitOfWork.Verify(uow => uow.UserRepository.AddUserAsync(It.IsAny<Domain.Users.User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
