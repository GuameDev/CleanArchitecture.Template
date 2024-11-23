using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.WeatherDates;

namespace CleanArchitecture.Template.SharedKernel.Tests.ValueObjects
{
    public class WeatherDateSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenValidDateIsProvided()
        {
            // Arrange
            var validDate = DateOnly.FromDateTime(DateTime.Now);

            // Act
            var result = WeatherDate.Create(validDate);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(validDate, result.Value.Value);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenMinValueDateIsProvided()
        {
            // Arrange
            var minValueDate = DateOnly.FromDateTime(DateTime.MinValue);

            // Act
            var result = WeatherDate.Create(minValueDate);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherDateErrors.MinValue, result.Error);
        }

        [Fact]
        public void WeatherDate_ShouldBeEqual_WhenValuesAreSame()
        {
            // Arrange
            var date = DateOnly.FromDateTime(DateTime.Now);
            var date1 = WeatherDate.Create(date).Value;
            var date2 = WeatherDate.Create(date).Value;

            // Act & Assert
            Assert.Equal(date1, date2);
            Assert.True(date1.Equals(date2));
            Assert.Equal(date1.GetHashCode(), date2.GetHashCode());
        }

        [Fact]
        public void WeatherDate_ShouldNotBeEqual_WhenValuesAreDifferent()
        {
            // Arrange
            var date1 = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value;
            var date2 = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now.AddDays(1))).Value;

            // Act & Assert
            Assert.NotEqual(date1, date2);
            Assert.False(date1.Equals(date2));
            Assert.NotEqual(date1.GetHashCode(), date2.GetHashCode());
        }
    }
}
