namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById
{
    public record WeatherForecastGetByIdResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, double TemperatureF);
}
