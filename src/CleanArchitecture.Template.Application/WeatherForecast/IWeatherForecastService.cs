using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync();
        Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request);
    }
}
