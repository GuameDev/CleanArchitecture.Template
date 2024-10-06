using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
{
    public class WeatherForecastEntityTypeConfiguration : BaseEntityConfiguration<WeatherForecast, Guid>
    {
        public override void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(weatherForecast => weatherForecast.Id);

            // Convert Summary to string for storing in the database
            builder.Property(weatherForecast => weatherForecast.Summary)
                   .HasConversion(
                       summary => summary.ToString(),
                       summary => (Summary)Enum.Parse(typeof(Summary), summary))
                   .IsRequired();

            builder.OwnsOne(weatherForecast => weatherForecast.Temperature, temp =>
            {
                temp.Property(t => t.Value).HasColumnName("TemperatureValue");
                temp.Property(t => t.Type).HasColumnName("TemperatureType").HasConversion(
                       summary => summary.ToString(),
                       summary => (TemperatureType)Enum.Parse(typeof(TemperatureType), summary))
                   .IsRequired(); ;
            });

            builder.OwnsOne(weatherForecast => weatherForecast.Date, date =>
            {
                date.Property(d => d.Value).HasColumnName("Date");
            });

            SeedDefaultData(builder);
        }

        private static void SeedDefaultData(EntityTypeBuilder<WeatherForecast> builder)
        {
            var random = new Random();
            var weatherForecasts = new List<object>();
            var temperatures = new List<object>();
            var dates = new List<object>();

            for (var i = 0; i < 20; i++)
            {
                var id = Guid.NewGuid();
                var summary = (Summary)random.Next(0, Enum.GetValues<Summary>().Length);
                var temperatureValue = (double)random.Next(-5, 35);
                var temperatureType = (TemperatureType)random.Next(0, 2);
                var dateValue = DateOnly.FromDateTime(DateTime.Now.AddDays(random.Next(-1000, 1000)));
                var now = DateTime.Now;

                weatherForecasts.Add(new
                {
                    Id = id,
                    Summary = summary,
                    CreatedDate = now,
                    UpdatedDate = now,
                });

                temperatures.Add(new
                {
                    WeatherForecastId = id,
                    Value = temperatureValue,
                    Type = temperatureType
                });

                dates.Add(new
                {
                    WeatherForecastId = id,
                    Value = dateValue
                });
            }

            builder.HasData(weatherForecasts);
            builder.OwnsOne(weatherForecast => weatherForecast.Temperature).HasData(temperatures);
            builder.OwnsOne(weatherForecast => weatherForecast.Date).HasData(dates);
        }
    }
}