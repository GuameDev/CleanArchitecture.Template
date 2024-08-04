using CleanArchitecture.Template.Domain.Constants;
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

            builder.Property(weatherForecast => weatherForecast.Summary)
                   .HasConversion(
                       summary => summary.ToString(),
                       summary => (Summary)Enum.Parse(typeof(Summary), summary));

            builder.OwnsOne(weatherForecast => weatherForecast.Temperature, temp =>
            {
                temp.Property(t => t.Value).HasColumnName("TemperatureValue");
                temp.Property(t => t.Type).HasColumnName("TemperatureType");
            });

            builder.OwnsOne(weatherForecast => weatherForecast.Date, date =>
            {
                date.Property(d => d.Value).HasColumnName("Date");
            });
        }
    }
}
