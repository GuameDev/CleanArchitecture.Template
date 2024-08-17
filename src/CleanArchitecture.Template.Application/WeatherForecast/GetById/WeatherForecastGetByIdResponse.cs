namespace CleanArchitecture.Template.Application.WeatherForecast.GetById
{
    public record WeatherForecastGetByIdResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
