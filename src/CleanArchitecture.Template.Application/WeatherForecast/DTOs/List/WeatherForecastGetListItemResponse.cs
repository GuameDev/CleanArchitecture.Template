namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.List
{
    public record WeatherForecastGetListItemResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
