namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById
{
    public record GetWeatherForecastByIdResponse
    {
        public Guid Id { get; init; }
        public DateOnly Date { get; init; }
        public string Summary { get; init; } = string.Empty;
        public double TemperatureCelsius { get; init; }
        public double TemperatureFahrenheit { get; init; }
    }
}
