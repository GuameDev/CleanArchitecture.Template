using CleanArchitecture.Template.Domain.Users;

namespace CleanArchitecture.Template.Application.Users.Services
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        bool IsAuthenticated { get; }
        Task<User?> GetCurrentUserAsync();
    }
}
