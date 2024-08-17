namespace CleanArchitecture.Template.Application.WeatherForecast.List
{
    public record WeatherForecastGetListItemResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
