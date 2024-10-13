using CleanArchitecture.Template.Application.Base.Messaging;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Delete
{
    public record DeleteWeatherForecastCommand(Guid Id) : ICommand { }
}
