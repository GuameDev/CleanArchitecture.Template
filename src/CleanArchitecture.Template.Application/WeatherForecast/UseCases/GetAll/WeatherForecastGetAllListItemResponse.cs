namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll
{
    public record WeatherForecastGetAllListItemResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
