using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultWeatherForecastData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), "Celsius", -5.0, new DateOnly(2024, 1, 1), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Scorching", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), "Celsius", 0.0, new DateOnly(2024, 1, 2), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Freezing", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), "Celsius", 5.0, new DateOnly(2024, 1, 3), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Chilly", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), "Celsius", 10.0, new DateOnly(2024, 1, 4), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Mild", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), "Celsius", 15.0, new DateOnly(2024, 1, 5), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Sweltering", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"));
        }
    }
}
