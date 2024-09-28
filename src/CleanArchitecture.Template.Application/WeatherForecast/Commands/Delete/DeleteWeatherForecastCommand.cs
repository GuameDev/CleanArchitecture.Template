using CleanArchitecture.Template.Application.Base.Messaging;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Delete
{
    public record DeleteWeatherForecastCommand(Guid Id) : ICommand { }
}
