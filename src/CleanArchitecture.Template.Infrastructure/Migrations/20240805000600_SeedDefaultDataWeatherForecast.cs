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
                columns: new[] { "Id", "Summary", "TemperatureType", "TemperatureValue", "Date" },
                values: new object[,]
                {
                    { new Guid("00668c3b-da72-4897-b2b7-088fc07745bd"), "Bracing", 0, 21.0, new DateOnly(2024, 1, 26) },
                    { new Guid("0dae66ae-2301-46c0-9a73-acc00cccc502"), "Cool", 0, -4.0, new DateOnly(2023, 3, 14) },
                    { new Guid("0fc746ef-fe20-477f-bc2c-cba82b790f4f"), "Freezing", 0, 12.0, new DateOnly(2024, 9, 23) },
                    { new Guid("14b4bf5e-9c5c-44ee-a149-5ad5adcc0c26"), "Cool", 0, 26.0, new DateOnly(2026, 12, 15) },
                    { new Guid("346c709a-bcc1-4fd5-bb21-af107be7ae08"), "Balmy", 0, -5.0, new DateOnly(2023, 5, 17) },
                    { new Guid("39aebc8f-28c7-46e7-9407-725d9a517521"), "Unknown", 0, 9.0, new DateOnly(2024, 4, 8) },
                    { new Guid("468d7d47-dd40-45e1-b3bf-59dfea65793b"), "Cool", 0, 11.0, new DateOnly(2022, 7, 16) },
                    { new Guid("5cc7ff59-f867-457e-b2db-958e89626327"), "Sweltering", 0, 34.0, new DateOnly(2025, 10, 15) },
                    { new Guid("609ab2ee-c99f-4970-9085-bb9d106e6793"), "Balmy", 0, -3.0, new DateOnly(2024, 7, 6) },
                    { new Guid("7e944825-5b9e-498d-8156-6bdc0b48c429"), "Sweltering", 0, 27.0, new DateOnly(2024, 12, 15) },
                    { new Guid("81e65eef-eae4-449d-bdea-6d4493b3c773"), "Bracing", 0, 9.0, new DateOnly(2023, 1, 7) },
                    { new Guid("8c2f0c14-0518-4772-8ffa-f15478fc9216"), "Balmy", 0, 22.0, new DateOnly(2026, 8, 8) },
                    { new Guid("8fa85d80-c8bd-493b-a170-011d0cc1398e"), "Warm", 0, 6.0, new DateOnly(2026, 2, 10) },
                    { new Guid("b415650c-320e-46e8-97dd-cbb9e891815f"), "Freezing", 0, 17.0, new DateOnly(2023, 7, 16) },
                    { new Guid("d75ce0bf-657e-4baf-aa21-0bb1b73cd5f8"), "Warm", 0, 29.0, new DateOnly(2025, 10, 3) },
                    { new Guid("d86b61a8-1c3a-474b-9af9-83052cc48f98"), "Mild", 0, 5.0, new DateOnly(2024, 10, 16) },
                    { new Guid("da5e3eb1-5b2f-46dc-8a0c-d1d0156f541b"), "Scorching", 0, 7.0, new DateOnly(2023, 4, 22) },
                    { new Guid("db492ae0-b851-42d6-8f59-ce69ca810538"), "Balmy", 0, 24.0, new DateOnly(2026, 1, 21) },
                    { new Guid("e4001aa6-3358-46b6-84a5-2e423ce90b94"), "Bracing", 0, -3.0, new DateOnly(2026, 9, 23) },
                    { new Guid("e9fbb1f4-4465-41ea-9816-0e2ced492072"), "Chilly", 0, 12.0, new DateOnly(2025, 3, 9) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("00668c3b-da72-4897-b2b7-088fc07745bd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0dae66ae-2301-46c0-9a73-acc00cccc502"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0fc746ef-fe20-477f-bc2c-cba82b790f4f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("14b4bf5e-9c5c-44ee-a149-5ad5adcc0c26"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("346c709a-bcc1-4fd5-bb21-af107be7ae08"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("39aebc8f-28c7-46e7-9407-725d9a517521"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("468d7d47-dd40-45e1-b3bf-59dfea65793b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5cc7ff59-f867-457e-b2db-958e89626327"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("609ab2ee-c99f-4970-9085-bb9d106e6793"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7e944825-5b9e-498d-8156-6bdc0b48c429"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("81e65eef-eae4-449d-bdea-6d4493b3c773"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8c2f0c14-0518-4772-8ffa-f15478fc9216"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8fa85d80-c8bd-493b-a170-011d0cc1398e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b415650c-320e-46e8-97dd-cbb9e891815f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d75ce0bf-657e-4baf-aa21-0bb1b73cd5f8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d86b61a8-1c3a-474b-9af9-83052cc48f98"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("da5e3eb1-5b2f-46dc-8a0c-d1d0156f541b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("db492ae0-b851-42d6-8f59-ce69ca810538"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e4001aa6-3358-46b6-84a5-2e423ce90b94"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e9fbb1f4-4465-41ea-9816-0e2ced492072"));
        }
    }
}
