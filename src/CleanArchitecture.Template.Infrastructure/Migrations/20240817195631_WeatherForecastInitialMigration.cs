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
                    { new Guid("00a63995-a7e4-42b2-8408-a31f5fc8abbf"), "Freezing", "Fahrenheit", 13.0, new DateOnly(2026, 6, 20) },
                    { new Guid("0851bbdc-cf71-4009-9ba2-d4b1020e4aa8"), "Scorching", "Celsius", 22.0, new DateOnly(2026, 7, 12) },
                    { new Guid("19775645-82a7-4f10-917d-5a1e82c403f2"), "Hot", "Celsius", 1.0, new DateOnly(2022, 1, 1) },
                    { new Guid("28259e9d-fa7d-4915-baa7-85cba9ca31d2"), "Scorching", "Fahrenheit", 22.0, new DateOnly(2024, 7, 5) },
                    { new Guid("30eeeaee-12b4-4176-88a5-0045e32bcb6b"), "Unknown", "Fahrenheit", -1.0, new DateOnly(2022, 12, 24) },
                    { new Guid("4583e970-640c-409b-85eb-8bd5fb84ae4d"), "Freezing", "Celsius", -3.0, new DateOnly(2023, 12, 27) },
                    { new Guid("4c1ba407-415e-4894-a489-d1f9541ea658"), "Hot", "Fahrenheit", 22.0, new DateOnly(2022, 3, 7) },
                    { new Guid("4e844bd9-f72d-41ea-9939-713fe9198b20"), "Warm", "Fahrenheit", 32.0, new DateOnly(2023, 1, 9) },
                    { new Guid("5229527d-cea0-43a2-b14f-3e714bb6e0fb"), "Cool", "Fahrenheit", 22.0, new DateOnly(2022, 7, 12) },
                    { new Guid("831d8fda-64ce-414b-8ecc-1a90dc9f51ad"), "Warm", "Fahrenheit", 10.0, new DateOnly(2023, 4, 30) },
                    { new Guid("834debb2-fd24-4b4f-8c5a-11f0a9926976"), "Unknown", "Celsius", 9.0, new DateOnly(2025, 7, 19) },
                    { new Guid("9aec4c12-0917-43e7-ac68-30b76b473b54"), "Scorching", "Celsius", 15.0, new DateOnly(2025, 4, 28) },
                    { new Guid("9c7212f2-28b4-4ef2-bb15-16d60b9863eb"), "Unknown", "Fahrenheit", -1.0, new DateOnly(2027, 2, 7) },
                    { new Guid("b4315a8a-af9f-4966-ab77-c6bce7dbfc27"), "Unknown", "Fahrenheit", 9.0, new DateOnly(2027, 1, 26) },
                    { new Guid("b7ee5b3a-e2ef-4aa5-9fe1-e9bac4f46ab2"), "Chilly", "Fahrenheit", 29.0, new DateOnly(2025, 11, 27) },
                    { new Guid("bdea3223-7e74-42dc-9daa-90602e60e403"), "Warm", "Fahrenheit", 12.0, new DateOnly(2022, 3, 25) },
                    { new Guid("c46f97e2-8b6c-4c67-97d5-b9224c374cee"), "Mild", "Fahrenheit", 1.0, new DateOnly(2026, 2, 23) },
                    { new Guid("c7d15f40-1ac1-4b53-a0e5-7401aa095687"), "Unknown", "Fahrenheit", 25.0, new DateOnly(2023, 2, 17) },
                    { new Guid("cd25b402-d580-46e4-b3fa-f0ccd4d0c34c"), "Balmy", "Celsius", 2.0, new DateOnly(2026, 4, 4) },
                    { new Guid("e709a49a-2ca8-418f-bad4-3aa58f0041e1"), "Chilly", "Fahrenheit", 21.0, new DateOnly(2025, 11, 25) }
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
