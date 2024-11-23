using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update
{
    public record UpdateWeatherForecastCommand(
        Guid Id,
        DateOnly Date,
        double Temperature,
        TemperatureType TemperatureType,
        Summary Summary) : ICommand<UpdateWeatherForecastResponse>
    { }
}
