using CleanArchitecture.Template.Domain.Users.Aggregates;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken entity);
    }
}
