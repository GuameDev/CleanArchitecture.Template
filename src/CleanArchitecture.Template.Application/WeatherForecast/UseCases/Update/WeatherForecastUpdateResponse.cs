namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update
{
    public record WeatherForecastUpdateResponse(Guid Id, DateOnly Date, string summary, double TemperatureC, double TemperatureF);
}
