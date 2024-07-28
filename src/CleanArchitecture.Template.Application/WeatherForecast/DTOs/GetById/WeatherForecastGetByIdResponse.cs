namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById
{
    public record WeatherForecastGetByIdResponse(Guid Id, DateOnly Date, string Summary, double TemperatureC, string TemperatureF);
}
