using CleanArchitecture.Template.Application.WeatherForecast.Queries.Get;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WeatherForecastRepository> _logger;

        public WeatherForecastRepository(
            ApplicationDbContext context,
            ILogger<WeatherForecastRepository> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(WeatherForecast weatherForecast)
        {
            await _context.WeatherForecasts.AddAsync(weatherForecast);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.WeatherForecasts.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<GetAllWeatherForecastResponse> GetAllAsync()
        {
            var entities = await _context.WeatherForecasts.ToListAsync();

            return new GetAllWeatherForecastResponse()
            {
                TotalCount = entities.Count,
                Elements = entities.Select(x => new GetAllWeatherForecastListItemResponse()
                {
                    Id = x.Id,
                    Date = x.Date.Value,
                    Summary = x.Summary.ToString(),
                    TemperatureCelsius = x.Temperature.ToCelsius(),
                    TemperatureFahrenheit = x.Temperature.ToFahrenheit()
                }),

            };
        }
        public Task<WeatherForecast?> GetByIdAsync(GetWeatherForecastByIdRequest request) => _context.WeatherForecasts
            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

        public async Task<GetWeatherForecastListResponse> GetListAsync(ISpecification<WeatherForecast> specification)
        {
            var query = ApplySpecification(specification).AsNoTracking();

            var totalItems = await query.CountAsync();

            var items = await query
                .Select(x => new GetWeatherForecastListItemResponse()
                {
                    Id = x.Id,
                    Date = x.Date.Value,
                    Summary = x.Summary.ToString(),
                    TemperatureCelsius = x.Temperature.ToCelsius(),
                    TemperatureFahrenheit = x.Temperature.ToFahrenheit()
                })
                .ToListAsync();

            return new GetWeatherForecastListResponse
            {
                Elements = items,
                TotalCount = totalItems,
                Page = specification.IsPagingEnabled ? specification.Page : null,
                PageSize = specification.IsPagingEnabled ? specification.PageSize : null,
            };
        }

        private IQueryable<WeatherForecast> ApplySpecification(ISpecification<WeatherForecast> specification) => SpecificationEvaluator<WeatherForecast>
            .GetQuery(_context.WeatherForecasts.AsQueryable(), specification);

        public async Task UpdateAsync(WeatherForecast weatherForecast)
        {
            _context.WeatherForecasts.Update(weatherForecast);
            await _context.SaveChangesAsync();
        }
    }
}
