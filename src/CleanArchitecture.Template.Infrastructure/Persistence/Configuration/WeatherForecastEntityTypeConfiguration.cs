using CleanArchitecture.Template.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
{
    public class WeatherForecastEntityTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(weatherForecast => weatherForecast.Id);

            builder.Property(weatherForecast => weatherForecast.Summary);

            builder.OwnsOne(weatherForecast => weatherForecast.Temperature, temp =>
            {
                temp.Property(weatherForecast => weatherForecast.Value).HasColumnName("TemperatureValue");
                temp.Property(weatherForecast => weatherForecast.Type).HasColumnName("TemperatureType");
            });

            builder.OwnsOne(weatherForecast => weatherForecast.Date, date =>
            {
                date.Property(weatherForecast => weatherForecast.Date).HasColumnName("Date");
            });
        }
    }
}
