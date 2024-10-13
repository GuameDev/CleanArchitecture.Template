using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;

namespace CleanArchitecture.Template.Application.Base.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IWeatherForecastRepository WeatherForecastRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
