using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WeatherForecastInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureValue = table.Column<double>(type: "float", nullable: false),
                    TemperatureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Summary", "TemperatureType", "TemperatureValue", "Date" },
                values: new object[,]
                {
                    { new Guid("023eccf0-05d0-495f-b890-c2f1649918a2"), "Mild", "Fahrenheit", 4.0, new DateOnly(2022, 3, 24) },
                    { new Guid("0aa9bd60-0527-4948-a552-b6bdc970c6fe"), "Hot", "Celsius", 15.0, new DateOnly(2023, 8, 1) },
                    { new Guid("1977f8fb-cf61-450b-a226-59071d78292b"), "Mild", "Fahrenheit", -5.0, new DateOnly(2024, 4, 20) },
                    { new Guid("21b5b494-b699-4cd9-92a1-f93d7a1ae89d"), "Balmy", "Celsius", 13.0, new DateOnly(2022, 8, 25) },
                    { new Guid("36dae24e-41cb-44b2-8ff7-32e425f985a1"), "Freezing", "Fahrenheit", 21.0, new DateOnly(2025, 7, 1) },
                    { new Guid("4c6b0c09-f3ce-49bd-a18e-6b2164c4732a"), "Unknown", "Fahrenheit", 23.0, new DateOnly(2023, 8, 24) },
                    { new Guid("4e83e289-28a6-44ea-b441-0ae79aad507d"), "Sweltering", "Celsius", 3.0, new DateOnly(2023, 5, 10) },
                    { new Guid("51138dcd-9663-4ad8-b3c2-fde18da242ae"), "Cool", "Fahrenheit", 34.0, new DateOnly(2023, 1, 3) },
                    { new Guid("513fb326-954e-437e-8e6a-d836a676e5c9"), "Sweltering", "Fahrenheit", 22.0, new DateOnly(2026, 9, 26) },
                    { new Guid("6239da15-2ad6-450f-89f9-7a7747ad2782"), "Mild", "Fahrenheit", 29.0, new DateOnly(2023, 5, 16) },
                    { new Guid("81d5a557-4476-4c46-b575-66e2b9fb886d"), "Unknown", "Fahrenheit", 8.0, new DateOnly(2024, 7, 8) },
                    { new Guid("85b92d6d-0400-49dc-848f-498c49d39398"), "Balmy", "Celsius", -2.0, new DateOnly(2022, 2, 19) },
                    { new Guid("99861ec8-afcf-40ce-bf69-506545ef3881"), "Bracing", "Fahrenheit", 29.0, new DateOnly(2024, 7, 2) },
                    { new Guid("a48dbd18-102f-48a8-81c5-5ea57425489e"), "Unknown", "Celsius", 22.0, new DateOnly(2024, 8, 30) },
                    { new Guid("af7ec632-c493-485a-ade8-1b22e174f758"), "Bracing", "Celsius", 14.0, new DateOnly(2026, 4, 22) },
                    { new Guid("b9da0708-19f1-4ece-9de1-1ea7b021cc30"), "Cool", "Celsius", -4.0, new DateOnly(2025, 7, 27) },
                    { new Guid("c16d209d-c279-4721-bfed-f9f3af3f39a1"), "Freezing", "Celsius", 26.0, new DateOnly(2026, 5, 26) },
                    { new Guid("d1619856-8b73-45e5-a2ba-d5274ed924eb"), "Chilly", "Fahrenheit", -4.0, new DateOnly(2026, 6, 18) },
                    { new Guid("e5b2ae1c-8089-48ad-aca5-dc0b622cfbcf"), "Chilly", "Fahrenheit", 10.0, new DateOnly(2022, 6, 6) },
                    { new Guid("f5609cad-8529-4968-b223-3d540c2247d2"), "Sweltering", "Celsius", 13.0, new DateOnly(2025, 12, 20) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
