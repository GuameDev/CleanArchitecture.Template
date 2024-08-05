using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Responses.PageList;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.WeatherForecasts.WeatherForecast?> GetByIdAsync(WeatherForecastGetByIdRequest request);
        Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAllAsync();
        Task<PageListResponse<WeatherForecastGetListItemResponse>> GetListAsync(ISpecification<Domain.WeatherForecasts.WeatherForecast> request);
        Task AddAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.WeatherForecasts.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
