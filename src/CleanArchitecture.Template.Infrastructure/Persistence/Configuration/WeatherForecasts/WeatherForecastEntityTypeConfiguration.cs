using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.WeatherForecasts
{
    public class WeatherForecastEntityTypeConfiguration : EntityTypeConfiguration<WeatherForecast, Guid>
    {
        public override void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            base.Configure(builder);

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
                   .IsRequired();
            });

            builder.OwnsOne(weatherForecast => weatherForecast.Date, date =>
            {
                date.Property(d => d.Value).HasColumnName("Date");
            });
        }
    }
}