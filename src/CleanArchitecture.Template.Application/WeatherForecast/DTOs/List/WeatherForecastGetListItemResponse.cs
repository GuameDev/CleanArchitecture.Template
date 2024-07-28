namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.List
{
    public record WeatherForecastGetListItemResponse(DateOnly Date, double TemperatureC, double TemperatureF, string Summary);
}
