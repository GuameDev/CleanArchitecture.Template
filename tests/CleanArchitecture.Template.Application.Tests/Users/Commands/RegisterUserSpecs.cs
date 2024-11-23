using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.Users.ValueObjects.Passwords;
using CleanArchitecture.Template.SharedKernel.Specification;
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
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRoleRepository = new Mock<IRoleRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(
                mockUnitOfWork.Object,
                mockUserRepository.Object,
                mockRoleRepository.Object,
                mockPasswordHasher.Object
            );

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            mockUserRepository
                .Setup(repo => repo.ExistAsync(It.IsAny<ISpecification<User>>()))
                .ReturnsAsync(false);

            mockPasswordHasher
                .Setup(ph => ph.Hash(It.IsAny<string>()))
                .Returns("hashedpassword");

            mockRoleRepository
                .Setup(repo => repo.GetByNameAsync(RoleName.User))
                .ReturnsAsync(Role.Create(Guid.NewGuid(), RoleName.User).Value);

            mockUserRepository
                .Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenUserAlreadyExists()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRoleRepository = new Mock<IRoleRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(
                mockUnitOfWork.Object,
                mockUserRepository.Object,
                mockRoleRepository.Object,
                mockPasswordHasher.Object
            );

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            mockUserRepository
                .Setup(repo => repo.ExistAsync(It.IsAny<ISpecification<User>>()))
                .ReturnsAsync(true);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.UserAlreadyExist, result.Error);
            mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenPasswordIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRoleRepository = new Mock<IRoleRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(
                mockUnitOfWork.Object,
                mockUserRepository.Object,
                mockRoleRepository.Object,
                mockPasswordHasher.Object
            );

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "weak" // Invalid password
            );

            mockUserRepository
                .Setup(repo => repo.ExistAsync(It.IsAny<ISpecification<User>>()))
                .ReturnsAsync(false);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(PasswordErrors.MinLengthPassword, result.Error);
            mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFailure_WhenDefaultRoleNotFound()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockRoleRepository = new Mock<IRoleRepository>();
            var mockPasswordHasher = new Mock<IUserPasswordHasher>();
            var handler = new RegisterUserHandler(
                mockUnitOfWork.Object,
                mockUserRepository.Object,
                mockRoleRepository.Object,
                mockPasswordHasher.Object
            );

            var request = new RegisterUserCommand(
                "johndoe",
                "johndoe@example.com",
                "John",
                "Doe",
                string.Empty,
                "StrongPass123!"
            );

            mockUserRepository
                .Setup(repo => repo.ExistAsync(It.IsAny<ISpecification<User>>()))
                .ReturnsAsync(false);

            mockPasswordHasher
                .Setup(ph => ph.Hash(It.IsAny<string>()))
                .Returns("hashedpassword");

            mockRoleRepository
                .Setup(repo => repo.GetByNameAsync(RoleName.User))
                .ReturnsAsync((Role?)null);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserErrors.DefaultRoleNotFound, result.Error);
            mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
