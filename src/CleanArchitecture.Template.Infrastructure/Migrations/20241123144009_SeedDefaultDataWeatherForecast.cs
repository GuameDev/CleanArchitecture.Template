using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultDataWeatherForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0c1cec78-ea45-444b-a500-8fc7761a4fe1"), "Celsius", 20.0, new DateOnly(2023, 11, 24), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(404), "Scorching", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(404) },
                    { new Guid("0d02b865-28c7-40ca-91ce-14155cfc02bd"), "Fahrenheit", 15.0, new DateOnly(2024, 3, 30), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(503), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(503) },
                    { new Guid("15593239-e01d-4dd9-b9a5-5074c08ce3ad"), "Fahrenheit", 17.0, new DateOnly(2023, 9, 12), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(499), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(499) },
                    { new Guid("157d9d0e-329f-4a40-94da-a79ab5fe9b69"), "Fahrenheit", -5.0, new DateOnly(2026, 9, 7), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(440), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(440) },
                    { new Guid("1d428048-92f0-42cd-a381-0c12acc5dc61"), "Fahrenheit", 14.0, new DateOnly(2023, 3, 18), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(435), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(435) },
                    { new Guid("25798d45-d9ac-48c1-8e96-46b184ebbedd"), "Celsius", 17.0, new DateOnly(2024, 1, 10), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(428), "Unknown", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(428) },
                    { new Guid("270b6a65-eaee-4a49-8a41-f15ba0a093e8"), "Fahrenheit", 29.0, new DateOnly(2022, 3, 18), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(415), "Sweltering", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(415) },
                    { new Guid("4d27b960-5474-40b1-9f24-7ff3eb02cf04"), "Celsius", 16.0, new DateOnly(2025, 8, 6), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(524), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(524) },
                    { new Guid("546cf3bb-268d-4446-ae25-6240bb0cfbaf"), "Fahrenheit", 4.0, new DateOnly(2022, 6, 6), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(508), "Balmy", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(508) },
                    { new Guid("646b86ee-9ddc-41ab-b562-d38c53c2280b"), "Celsius", -3.0, new DateOnly(2023, 10, 10), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(489), "Scorching", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(489) },
                    { new Guid("6e456178-6db8-425b-9bfc-de9ccad22c7d"), "Fahrenheit", 4.0, new DateOnly(2023, 7, 31), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(478), "Warm", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(478) },
                    { new Guid("760faed7-de9f-4d31-9f5f-6ead04862b4e"), "Fahrenheit", 3.0, new DateOnly(2025, 6, 4), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(420), "Mild", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(420) },
                    { new Guid("8273e1bd-fc99-47f3-805b-f7a7290a7c8c"), "Fahrenheit", 3.0, new DateOnly(2025, 4, 8), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(410), "Hot", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(410) },
                    { new Guid("8712d094-a4bf-4abf-974d-d3b7fa881d52"), "Fahrenheit", -1.0, new DateOnly(2023, 12, 31), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(393), "Mild", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(393) },
                    { new Guid("8e85b4b9-88ac-4bc8-8692-d7b1ef1f039e"), "Celsius", 18.0, new DateOnly(2027, 6, 13), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(515), "Cool", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(515) },
                    { new Guid("9381fdc9-2d64-4afb-ad17-7b70eb44e1d5"), "Fahrenheit", 0.0, new DateOnly(2024, 5, 18), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(532), "Cool", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(532) },
                    { new Guid("b1e542bd-1323-473b-9d07-d2cd2786fa5b"), "Celsius", 6.0, new DateOnly(2027, 3, 23), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(494), "Hot", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(494) },
                    { new Guid("bcd9b555-55bb-4e3b-b0a7-8c5d285443b1"), "Celsius", -5.0, new DateOnly(2027, 3, 23), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(519), "Chilly", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(519) },
                    { new Guid("cf2f9cbc-0b30-46b9-9ad5-c7fc50130f58"), "Celsius", -1.0, new DateOnly(2022, 10, 12), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(541), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(541) },
                    { new Guid("fb2c192f-e32c-477e-b736-3049586fdb92"), "Celsius", 13.0, new DateOnly(2023, 7, 8), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(536), "Balmy", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(536) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0c1cec78-ea45-444b-a500-8fc7761a4fe1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0d02b865-28c7-40ca-91ce-14155cfc02bd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("15593239-e01d-4dd9-b9a5-5074c08ce3ad"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("157d9d0e-329f-4a40-94da-a79ab5fe9b69"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1d428048-92f0-42cd-a381-0c12acc5dc61"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("25798d45-d9ac-48c1-8e96-46b184ebbedd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("270b6a65-eaee-4a49-8a41-f15ba0a093e8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4d27b960-5474-40b1-9f24-7ff3eb02cf04"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("546cf3bb-268d-4446-ae25-6240bb0cfbaf"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("646b86ee-9ddc-41ab-b562-d38c53c2280b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6e456178-6db8-425b-9bfc-de9ccad22c7d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("760faed7-de9f-4d31-9f5f-6ead04862b4e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8273e1bd-fc99-47f3-805b-f7a7290a7c8c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8712d094-a4bf-4abf-974d-d3b7fa881d52"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8e85b4b9-88ac-4bc8-8692-d7b1ef1f039e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9381fdc9-2d64-4afb-ad17-7b70eb44e1d5"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b1e542bd-1323-473b-9d07-d2cd2786fa5b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bcd9b555-55bb-4e3b-b0a7-8c5d285443b1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("cf2f9cbc-0b30-46b9-9ad5-c7fc50130f58"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("fb2c192f-e32c-477e-b736-3049586fdb92"));
        }
    }
}
