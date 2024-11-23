using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.WeatherDates;

namespace CleanArchitecture.Template.Domain.Tests.WeatherForecasts
{
    public class WeatherForecastSpecs
    {
        public class WeatherForecastTests
        {
            [Fact]
            public void Create_ShouldReturnSuccessResult_WhenValidInputs()
            {
                // Arrange
                var date = DateOnly.FromDateTime(DateTime.Now);
                var temperatureValue = 25;
                var temperatyreType = TemperatureType.Celsius;
                var summary = Summary.Mild;

                // Act
                var weatherForecastResult = WeatherForecast.Create(date, temperatureValue, temperatyreType, summary);

                // Assert
                Assert.True(weatherForecastResult.IsSuccess);
                Assert.NotNull(weatherForecastResult.Value);
                Assert.Equal(date, weatherForecastResult.Value.Date.Value);
                Assert.Equal(temperatureValue, weatherForecastResult.Value.Temperature.ToCelsius());
                Assert.Equal(summary, weatherForecastResult.Value.Summary);
            }

            [Fact]
            public void UpdateTemperature_ShouldChangeTemperature_WhenValidTemperatureProvided()
            {
                // Arrange
                var date = DateOnly.FromDateTime(DateTime.Now);
                var initialTemperatureValue = 20;
                var initialTemperatureType = TemperatureType.Celsius;
                var weatherForecastResult = WeatherForecast.Create(date, initialTemperatureValue, initialTemperatureType, Summary.Mild);
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
                var date = DateOnly.FromDateTime(DateTime.Now);
                var initialTemperatureValue = 20;
                var initialTemperatureType = TemperatureType.Celsius;
                var weatherForecastResult = WeatherForecast.Create(date, initialTemperatureValue, initialTemperatureType, Summary.Mild);
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
                var date = DateOnly.FromDateTime(DateTime.MinValue); // Invalid date
                var initialTemperatureValue = 20;
                var initialTemperatureType = TemperatureType.Celsius;

                // Act
                var weatherForecastResult = WeatherForecast.Create(date, initialTemperatureValue, initialTemperatureType, Summary.Mild);


                // Assert
                Assert.False(weatherForecastResult.IsSuccess);
                Assert.Equal(WeatherDateErrors.MinValue, weatherForecastResult.Error);
            }

            [Fact]
            public void Create_ShouldReturnFailureResult_WhenTemperatureIsInvalid()
            {
                // Arrange
                var date = DateOnly.FromDateTime(DateTime.Now);
                var initialTemperatureValue = -300;
                var initialTemperatureType = TemperatureType.Celsius;

                // Act
                var weatherForecastResult = WeatherForecast.Create(date, initialTemperatureValue, initialTemperatureType, Summary.Mild);

                // Assert
                Assert.False(weatherForecastResult.IsSuccess);
                Assert.Equal(TemperatureErrors.UnderZeroCelsius, weatherForecastResult.Error);
            }
        }
    }
}