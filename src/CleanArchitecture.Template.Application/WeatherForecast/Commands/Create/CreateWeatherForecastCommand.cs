using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Create
{
    public record CreateWeatherForecastCommand(DateOnly Date, double Temperature, TemperatureType TemperatureType, Summary Summary) : IRequest<Result<WeatherForecastCreateResponse>>;
}
