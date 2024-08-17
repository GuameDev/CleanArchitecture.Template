namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.List
{
    public record WeatherForecastGetListItemResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
