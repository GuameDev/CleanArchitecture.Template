using CleanArchitecture.Template.Application.WeatherForecast.Repository;

namespace CleanArchitecture.Template.Application.Base.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IWeatherForecastRepository WeatherForecastRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
