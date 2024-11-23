using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.WeatherForecasts
{
    public static class WeatherForecastDefaultDataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var fixedCreatedDate = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var fixedUpdatedDate = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);

            // Hardcoded WeatherForecast data
            modelBuilder.Entity<WeatherForecast>().HasData(
                new { Id = Guid.Parse("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), Summary = Summary.Scorching, CreatedDate = fixedCreatedDate, UpdatedDate = fixedUpdatedDate },
                new { Id = Guid.Parse("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), Summary = Summary.Freezing, CreatedDate = fixedCreatedDate, UpdatedDate = fixedUpdatedDate },
                new { Id = Guid.Parse("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), Summary = Summary.Chilly, CreatedDate = fixedCreatedDate, UpdatedDate = fixedUpdatedDate },
                new { Id = Guid.Parse("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), Summary = Summary.Mild, CreatedDate = fixedCreatedDate, UpdatedDate = fixedUpdatedDate },
                new { Id = Guid.Parse("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), Summary = Summary.Sweltering, CreatedDate = fixedCreatedDate, UpdatedDate = fixedUpdatedDate }
            );

            // Hardcoded Temperature data
            modelBuilder.Entity<WeatherForecast>().OwnsOne(wf => wf.Temperature).HasData(
                new { WeatherForecastId = Guid.Parse("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), Value = -5.0, Type = TemperatureType.Celsius },
                new { WeatherForecastId = Guid.Parse("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), Value = 0.0, Type = TemperatureType.Celsius },
                new { WeatherForecastId = Guid.Parse("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), Value = 5.0, Type = TemperatureType.Celsius },
                new { WeatherForecastId = Guid.Parse("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), Value = 10.0, Type = TemperatureType.Celsius },
                new { WeatherForecastId = Guid.Parse("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), Value = 15.0, Type = TemperatureType.Celsius }
            );

            // Hardcoded Date data
            modelBuilder.Entity<WeatherForecast>().OwnsOne(wf => wf.Date).HasData(
                new { WeatherForecastId = Guid.Parse("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), Value = DateOnly.FromDateTime(new DateTime(2024, 1, 1)) },
                new { WeatherForecastId = Guid.Parse("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), Value = DateOnly.FromDateTime(new DateTime(2024, 1, 2)) },
                new { WeatherForecastId = Guid.Parse("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), Value = DateOnly.FromDateTime(new DateTime(2024, 1, 3)) },
                new { WeatherForecastId = Guid.Parse("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), Value = DateOnly.FromDateTime(new DateTime(2024, 1, 4)) },
                new { WeatherForecastId = Guid.Parse("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), Value = DateOnly.FromDateTime(new DateTime(2024, 1, 5)) }
            );
        }
    }
}
