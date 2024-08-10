namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.Create
{
    public record WeatherForecastCreateResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
