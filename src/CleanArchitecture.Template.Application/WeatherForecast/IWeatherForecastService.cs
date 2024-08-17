using CleanArchitecture.Template.Application.WeatherForecast.Create;
using CleanArchitecture.Template.Application.WeatherForecast.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.List;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync();
        Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request);
        Task<Result<WeatherForecastCreateResponse>> CreateAsync(WeatherForecastCreateRequest request);
        Task<Result<WeatherForecastGetByIdResponse>> GetById(WeatherForecastGetByIdRequest request);
    }
}
