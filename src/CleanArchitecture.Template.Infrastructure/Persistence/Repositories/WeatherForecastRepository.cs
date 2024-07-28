using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.Base.Specification;
using CleanArchitecture.Template.Application.WeatherForecast;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.Domain.Entities;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        public Task AddAsync(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecastGetAllListItemResponse>> GetAllAsync(WeatherForecastGetListRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> GetByIdAsync(WeatherForecastGetByIdRequest request)
        {
            SpecificationEvaluator
            throw new NotImplementedException();
        }

        public Task<PageListResponse<WeatherForecastGetListItemResponse>> GetFilteredAsync(ISpecification<WeatherForecast> request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }
    }
}
