using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create
{
    public record CreateWeatherForecastCommand(
        DateOnly Date,
        double Temperature,
        TemperatureType TemperatureType,
        Summary Summary) : ICommand<CreateWeatherForecastResponse>
    { }
}
