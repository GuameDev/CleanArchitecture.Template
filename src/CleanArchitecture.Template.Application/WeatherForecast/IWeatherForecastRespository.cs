using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.Base.Specification;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.Entities.WeatherForecast> GetByIdAsync(WeatherForecastGetByIdRequest request);
        Task<IEnumerable<WeatherForecastGetAllListItemResponse>> GetAllAsync(WeatherForecastGetListRequest request);
        Task<PageListResponse<WeatherForecastGetListItemResponse>> GetFilteredAsync(ISpecification<Domain.Entities.WeatherForecast> request);
        Task AddAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
