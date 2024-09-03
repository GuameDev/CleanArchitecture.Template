using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync();
        Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request);
        Task<Result<CreateWeatherForecastResponse>> CreateAsync(WeatherForecastCreateRequest request);
        Task<Result<WeatherForecastGetByIdResponse>> GetById(WeatherForecastGetByIdRequest request);
        Task<Result> DeleteAsync(WeatherForecastDeleteRequest request);
        Task<Result<WeatherForecastUpdateResponse>> UpdateAsync(WeatherForecastUpdateRequest request);
    }
}
