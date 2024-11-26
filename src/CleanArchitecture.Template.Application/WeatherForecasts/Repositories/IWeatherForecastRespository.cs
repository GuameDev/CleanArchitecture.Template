using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.SharedKernel.Repository;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Repositories
{
    public interface IWeatherForecastRepository : IRepository<WeatherForecast>
    {
    }
}
