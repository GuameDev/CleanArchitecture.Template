using CleanArchitecture.Template.Application.WeatherForecast.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.List;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.Entities.WeatherForecast?> GetByIdAsync(WeatherForecastGetByIdRequest request);
        Task<WeatherForecastGetAllListResponse> GetAllAsync();
        Task<WeatherForecastGetListResponse> GetListAsync(ISpecification<Domain.Entities.WeatherForecast> request);
        Task AddAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
