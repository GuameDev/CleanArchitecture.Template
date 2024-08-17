namespace CleanArchitecture.Template.Application.WeatherForecast.GetAll
{
    public record WeatherForecastGetAllListItemResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
