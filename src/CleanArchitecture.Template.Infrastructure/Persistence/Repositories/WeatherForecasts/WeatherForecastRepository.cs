using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.WeatherForecasts
{
    internal class WeatherForecastRepository : Repository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
