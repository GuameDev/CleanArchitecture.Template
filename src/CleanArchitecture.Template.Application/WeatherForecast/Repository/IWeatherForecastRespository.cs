using CleanArchitecture.Template.Application.WeatherForecast.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecast.Repository
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.WeatherForecasts.WeatherForecast?> GetByIdAsync(GetWeatherForecastByIdRequest request);
        Task<GetAllWeatherForecastResponse> GetAllAsync();
        Task<GetWeatherForecastListResponse> GetListAsync(ISpecification<Domain.WeatherForecasts.WeatherForecast> request);
        Task AddAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
