using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecast.Repository
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.WeatherForecasts.WeatherForecast?> GetByIdAsync(GetWeatherForecastByIdRequest request);
        Task<GetAllWeatherForecastResponse> GetAllAsync();
        Task<WeatherForecastGetListResponse> GetListAsync(ISpecification<Domain.WeatherForecasts.WeatherForecast> request);
        Task AddAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
