using CleanArchitecture.Template.Application.WeatherForecast;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.Domain.Entities;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherForecastGetAllListResponse> GetAllAsync()
        {
            var entities = await _context.WeatherForecasts.ToListAsync();

            return new WeatherForecastGetAllListResponse()
            {
                Elements = entities.Select(x => new WeatherForecastGetAllListItemResponse(
                 x.Id,
                 x.Date.Value,
                 x.Summary.ToString(),
                 x.Temperature.ToCelsius(),
                 x.Temperature.ToFahrenheit())),

                TotalCount = entities.Count
            };
        }

        public Task<WeatherForecast?> GetByIdAsync(WeatherForecastGetByIdRequest request) => _context.WeatherForecasts
            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

        public async Task<WeatherForecastGetListResponse> GetListAsync(ISpecification<WeatherForecast> specification)
        {
            var query = ApplySpecification(specification).AsNoTracking();

            var totalItems = await query.CountAsync();

            var items = await query.Select(x => new WeatherForecastGetListItemResponse(
                                       x.Id,
                                       x.Date.Value,
                                       x.Summary.ToString(),
                                       x.Temperature.ToCelsius(),
                                       x.Temperature.ToFahrenheit()))
                                   .ToListAsync();

            return new WeatherForecastGetListResponse
            {
                Elements = items,
                TotalCount = totalItems,
                Page = specification.IsPagingEnabled ? specification.Page : null,
                PageSize = specification.IsPagingEnabled ? specification.PageSize : null,
            };
        }

        private IQueryable<WeatherForecast> ApplySpecification(ISpecification<WeatherForecast> specification) => SpecificationEvaluator<WeatherForecast>
            .GetQuery(_context.WeatherForecasts.AsQueryable(), specification);

        public Task UpdateAsync(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }
    }
}
