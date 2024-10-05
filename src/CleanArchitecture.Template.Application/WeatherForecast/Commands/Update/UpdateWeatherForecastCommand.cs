using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Update.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Update
{
    public record UpdateWeatherForecastCommand(
        Guid Id,
        DateOnly Date,
        double Temperature,
        TemperatureType TemperatureType,
        Summary Summary) : ICommand<UpdateWeatherForecastResponse>
    { }
}
