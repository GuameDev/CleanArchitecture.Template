using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        Task<Result<GetAllWeatherForecastResponse>> GetAllAsync();
        Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request);
        Task<Result<GetWeatherForecastByIdResponse>> GetById(GetWeatherForecastByIdRequest request);
        Task<Result> DeleteAsync(WeatherForecastDeleteRequest request);
    }
}
