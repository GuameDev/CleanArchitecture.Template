using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.WeatherForecasts.WeatherForecast?> GetByIdAsync(GetWeatherForecastByIdRequest request);
        Task<GetAllWeatherForecastResponse> GetAllAsync();
        Task<GetWeatherForecastListResponse> GetListAsync(ISpecification<Domain.WeatherForecasts.WeatherForecast> request);
        Task AddAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        void Update(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
