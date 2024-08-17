using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;

namespace CleanArchitecture.Template.Domain.Tests
{
    public class WeatherForecastSpecs
    {
        public class WeatherForecastTests
        {
            [Fact]
            public void Create_ShouldReturnSuccessResult_WhenValidInputs()
            {
                // Arrange
                var dateResult = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now));
                var temperatureResult = Temperature.FromCelsius(25);
                var summary = Summary.Mild;

                // Act
                var weatherForecastResult = WeatherForecast.Create(dateResult, temperatureResult, summary);

                // Assert
                Assert.True(weatherForecastResult.IsSuccess);
                Assert.NotNull(weatherForecastResult.Value);
                Assert.Equal(dateResult.Value, weatherForecastResult.Value.Date);
                Assert.Equal(temperatureResult.Value, weatherForecastResult.Value.Temperature);
                Assert.Equal(summary, weatherForecastResult.Value.Summary);
            }

            [Fact]
            public void UpdateTemperature_ShouldChangeTemperature_WhenValidTemperatureProvided()
            {
                // Arrange
                var dateResult = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now));
                var initialTemperatureResult = Temperature.FromCelsius(20);
                var weatherForecastResult = WeatherForecast.Create(dateResult, initialTemperatureResult, Summary.Mild);
                var newTemperatureResult = Temperature.FromFahrenheit(68);

                // Act
                weatherForecastResult.Value.UpdateTemperature(newTemperatureResult.Value);

                // Assert
                Assert.Equal(newTemperatureResult.Value, weatherForecastResult.Value.Temperature);
            }

            [Fact]
            public void UpdateSummary_ShouldChangeSummary_WhenNewSummaryProvided()
            {
                // Arrange
                var dateResult = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now));
                var temperatureResult = Temperature.FromCelsius(20);
                var weatherForecastResult = WeatherForecast.Create(dateResult, temperatureResult, Summary.Mild);
                var newSummary = Summary.Hot;

                // Act
                weatherForecastResult.Value.UpdateSummary(newSummary);

                // Assert
                Assert.Equal(newSummary, weatherForecastResult.Value.Summary);
            }
            [Fact]
            public void Create_ShouldReturnFailureResult_WhenDateIsInvalid()
            {
                // Arrange
                var dateResult = WeatherDate.Create(DateOnly.FromDateTime(DateTime.MinValue)); // Invalid date
                var temperatureResult = Temperature.FromCelsius(25);
                var summary = Summary.Mild;

                // Act
                var weatherForecastResult = WeatherForecast.Create(dateResult, temperatureResult, summary);

                // Assert
                Assert.False(weatherForecastResult.IsSuccess);
                Assert.Equal(WeatherDateErrors.MinValue, weatherForecastResult.Error);
            }

            [Fact]
            public void Create_ShouldReturnFailureResult_WhenTemperatureIsInvalid()
            {
                // Arrange
                var dateResult = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now));
                var temperatureResult = Temperature.FromCelsius(-300); // Below absolute zero

                // Act
                var weatherForecastResult = WeatherForecast.Create(dateResult, temperatureResult, Summary.Mild);

                // Assert
                Assert.False(weatherForecastResult.IsSuccess);
                Assert.Equal(TemperatureErrors.UnderZeroCelsius, weatherForecastResult.Error);
            }
        }
    }
}