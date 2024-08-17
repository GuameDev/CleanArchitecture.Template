namespace CleanArchitecture.Template.SharedKernel.Tests.ValueObjects
{
    using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
    using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
    using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
    using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
    using Xunit;

    public class TemperatureSpecs
    {
        [Fact]
        public void FromCelsius_ShouldReturnSuccess_WhenTemperatureIsValid()
        {
            // Arrange
            double validCelsius = 25;

            // Act
            var result = Temperature.FromCelsius(validCelsius);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(validCelsius, result.Value.Value);
            Assert.Equal(TemperatureType.Celsius, result.Value.Type);
        }

        [Fact]
        public void FromCelsius_ShouldReturnFailure_WhenTemperatureIsBelowAbsoluteZero()
        {
            // Arrange
            double invalidCelsius = TemperatureConstants.AbsoluteZeroCelsius - 1;

            // Act
            var result = Temperature.FromCelsius(invalidCelsius);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);
        }

        [Fact]
        public void FromFahrenheit_ShouldReturnSuccess_WhenTemperatureIsValid()
        {
            // Arrange
            double validFahrenheit = 77;

            // Act
            var result = Temperature.FromFahrenheit(validFahrenheit);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(validFahrenheit, result.Value.Value);
            Assert.Equal(TemperatureType.Fahrenheit, result.Value.Type);
        }

        [Fact]
        public void FromFahrenheit_ShouldReturnFailure_WhenTemperatureIsBelowAbsoluteZero()
        {
            // Arrange
            double invalidFahrenheit = TemperatureConstants.AbsoluteZeroFahrenheit - 1;

            // Act
            var result = Temperature.FromFahrenheit(invalidFahrenheit);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroFahrenheit, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnSuccess_WhenTemperatureTypeIsValid()
        {
            // Arrange
            double temperatureValue = 25;
            TemperatureType temperatureType = TemperatureType.Celsius;

            // Act
            var result = Temperature.Create(temperatureValue, temperatureType);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(temperatureValue, result.Value.Value);
            Assert.Equal(temperatureType, result.Value.Type);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenTemperatureTypeIsInvalid()
        {
            // Arrange
            double temperatureValue = 25;
            TemperatureType temperatureType = (TemperatureType)99; // Invalid enum value

            // Act
            var result = Temperature.Create(temperatureValue, temperatureType);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.InvalidTemperatureType, result.Error);
        }

        [Fact]
        public void ToCelsius_ShouldConvertCorrectly_WhenTemperatureIsInFahrenheit()
        {
            // Arrange
            double fahrenheitValue = 77;
            var result = Temperature.FromFahrenheit(fahrenheitValue);
            double expectedCelsius = (fahrenheitValue - 32) * 5 / 9;

            // Act
            double actualCelsius = result.Value.ToCelsius();

            // Assert
            Assert.Equal(expectedCelsius, actualCelsius, precision: 2);
        }

        [Fact]
        public void ToFahrenheit_ShouldConvertCorrectly_WhenTemperatureIsInCelsius()
        {
            // Arrange
            double celsiusValue = 25;
            var result = Temperature.FromCelsius(celsiusValue);
            double expectedFahrenheit = (celsiusValue * 9 / 5) + 32;

            // Act
            double actualFahrenheit = result.Value.ToFahrenheit();

            // Assert
            Assert.Equal(expectedFahrenheit, actualFahrenheit, precision: 2);
        }

        [Fact]
        public void Temperature_ShouldBeEqual_WhenValuesAndTypesAreSame()
        {
            // Arrange
            var temp1 = Temperature.FromCelsius(25).Value;
            var temp2 = Temperature.FromCelsius(25).Value;

            // Act & Assert
            Assert.Equal(temp1, temp2);
            Assert.True(temp1.Equals(temp2));
            Assert.Equal(temp1.GetHashCode(), temp2.GetHashCode());
        }

        [Fact]
        public void Temperature_ShouldNotBeEqual_WhenValuesOrTypesAreDifferent()
        {
            // Arrange
            var temp1 = Temperature.FromCelsius(25).Value;
            var temp2 = Temperature.FromFahrenheit(77).Value;

            // Act & Assert
            Assert.NotEqual(temp1, temp2);
            Assert.False(temp1.Equals(temp2));
            Assert.NotEqual(temp1.GetHashCode(), temp2.GetHashCode());
        }
    }

}
