using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TemperatureTypeAsStringWeatherForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TemperatureType",
                table: "WeatherForecasts",
                newName: "Temperature_Type");

            migrationBuilder.AlterColumn<string>(
                name: "Temperature_Type",
                table: "WeatherForecasts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Summary", "Temperature_Type", "TemperatureValue", "Date" },
                values: new object[,]
                {
                    { new Guid("0a2cd0d5-1224-45fd-9a41-814b95b0df26"), "Sweltering", "Celsius", 11.0, new DateOnly(2027, 2, 28) },
                    { new Guid("251ab013-66b1-4ca8-9192-d50d7c971400"), "Cool", "Celsius", 8.0, new DateOnly(2025, 8, 28) },
                    { new Guid("39e6221d-fee0-42a2-bb94-1c9cc24843e8"), "Bracing", "Celsius", 21.0, new DateOnly(2027, 2, 3) },
                    { new Guid("3e5dca62-8777-4645-8f9f-2b0268c40a0f"), "Sweltering", "Celsius", 10.0, new DateOnly(2023, 8, 25) },
                    { new Guid("4686ebb6-3345-40b5-8ace-e1ad26fef857"), "Cool", "Celsius", 5.0, new DateOnly(2027, 4, 30) },
                    { new Guid("46ce2aaa-f175-4268-a4cb-b66e4e581dd9"), "Freezing", "Celsius", 25.0, new DateOnly(2026, 10, 24) },
                    { new Guid("4ac266fc-117d-4dbe-b3d2-7f002f76e4f9"), "Scorching", "Celsius", 34.0, new DateOnly(2026, 6, 11) },
                    { new Guid("4fabdac5-48c5-4d42-9fba-ed17a5013e7d"), "Chilly", "Celsius", 14.0, new DateOnly(2024, 4, 12) },
                    { new Guid("5f36a8ad-97e6-424d-ad93-a8019daf2d6a"), "Sweltering", "Celsius", 5.0, new DateOnly(2026, 7, 22) },
                    { new Guid("5f930764-66fd-413f-85e3-c013373e044f"), "Sweltering", "Celsius", 16.0, new DateOnly(2025, 12, 15) },
                    { new Guid("615ec5de-7490-43f9-9de6-a33d095c62a5"), "Balmy", "Celsius", 15.0, new DateOnly(2025, 4, 9) },
                    { new Guid("7ee8f27c-e0b3-43a1-94c6-48d08c8ec2fd"), "Unknown", "Celsius", 15.0, new DateOnly(2021, 11, 10) },
                    { new Guid("82c1c5b0-a65c-406a-bc79-8e8d8de58ef8"), "Mild", "Celsius", 6.0, new DateOnly(2022, 4, 3) },
                    { new Guid("96d54ef4-fc11-43f1-b0b0-06a0e0378bfc"), "Unknown", "Celsius", 1.0, new DateOnly(2025, 12, 22) },
                    { new Guid("a5cc7ead-9261-4fa8-ada7-578e2ef80d8b"), "Unknown", "Celsius", 25.0, new DateOnly(2026, 2, 24) },
                    { new Guid("b6a75246-6c38-409a-a630-0e157644b737"), "Freezing", "Celsius", 17.0, new DateOnly(2023, 9, 21) },
                    { new Guid("b818ae64-8e64-437a-870b-62b8542b4b23"), "Balmy", "Celsius", -1.0, new DateOnly(2026, 4, 9) },
                    { new Guid("c6597222-1302-4d8d-ab27-08f24a0cfbef"), "Hot", "Celsius", 5.0, new DateOnly(2023, 9, 29) },
                    { new Guid("deecc17a-f088-4003-89e6-81c0c9b38d00"), "Chilly", "Celsius", 5.0, new DateOnly(2025, 2, 15) },
                    { new Guid("fb2a5e54-d46b-4fd6-811f-c9e1e96d0325"), "Cool", "Celsius", 29.0, new DateOnly(2024, 4, 13) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0a2cd0d5-1224-45fd-9a41-814b95b0df26"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("251ab013-66b1-4ca8-9192-d50d7c971400"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("39e6221d-fee0-42a2-bb94-1c9cc24843e8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3e5dca62-8777-4645-8f9f-2b0268c40a0f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4686ebb6-3345-40b5-8ace-e1ad26fef857"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("46ce2aaa-f175-4268-a4cb-b66e4e581dd9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4ac266fc-117d-4dbe-b3d2-7f002f76e4f9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4fabdac5-48c5-4d42-9fba-ed17a5013e7d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5f36a8ad-97e6-424d-ad93-a8019daf2d6a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5f930764-66fd-413f-85e3-c013373e044f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("615ec5de-7490-43f9-9de6-a33d095c62a5"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7ee8f27c-e0b3-43a1-94c6-48d08c8ec2fd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("82c1c5b0-a65c-406a-bc79-8e8d8de58ef8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("96d54ef4-fc11-43f1-b0b0-06a0e0378bfc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a5cc7ead-9261-4fa8-ada7-578e2ef80d8b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b6a75246-6c38-409a-a630-0e157644b737"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b818ae64-8e64-437a-870b-62b8542b4b23"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c6597222-1302-4d8d-ab27-08f24a0cfbef"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("deecc17a-f088-4003-89e6-81c0c9b38d00"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("fb2a5e54-d46b-4fd6-811f-c9e1e96d0325"));

            migrationBuilder.RenameColumn(
                name: "Temperature_Type",
                table: "WeatherForecasts",
                newName: "TemperatureType");

            migrationBuilder.AlterColumn<int>(
                name: "TemperatureType",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Summary", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("00668c3b-da72-4897-b2b7-088fc07745bd"), "Bracing", new DateOnly(2024, 1, 26), 0, 21.0 },
                    { new Guid("0dae66ae-2301-46c0-9a73-acc00cccc502"), "Cool", new DateOnly(2023, 3, 14), 0, -4.0 },
                    { new Guid("0fc746ef-fe20-477f-bc2c-cba82b790f4f"), "Freezing", new DateOnly(2024, 9, 23), 0, 12.0 },
                    { new Guid("14b4bf5e-9c5c-44ee-a149-5ad5adcc0c26"), "Cool", new DateOnly(2026, 12, 15), 0, 26.0 },
                    { new Guid("346c709a-bcc1-4fd5-bb21-af107be7ae08"), "Balmy", new DateOnly(2023, 5, 17), 0, -5.0 },
                    { new Guid("39aebc8f-28c7-46e7-9407-725d9a517521"), "Unknown", new DateOnly(2024, 4, 8), 0, 9.0 },
                    { new Guid("468d7d47-dd40-45e1-b3bf-59dfea65793b"), "Cool", new DateOnly(2022, 7, 16), 0, 11.0 },
                    { new Guid("5cc7ff59-f867-457e-b2db-958e89626327"), "Sweltering", new DateOnly(2025, 10, 15), 0, 34.0 },
                    { new Guid("609ab2ee-c99f-4970-9085-bb9d106e6793"), "Balmy", new DateOnly(2024, 7, 6), 0, -3.0 },
                    { new Guid("7e944825-5b9e-498d-8156-6bdc0b48c429"), "Sweltering", new DateOnly(2024, 12, 15), 0, 27.0 },
                    { new Guid("81e65eef-eae4-449d-bdea-6d4493b3c773"), "Bracing", new DateOnly(2023, 1, 7), 0, 9.0 },
                    { new Guid("8c2f0c14-0518-4772-8ffa-f15478fc9216"), "Balmy", new DateOnly(2026, 8, 8), 0, 22.0 },
                    { new Guid("8fa85d80-c8bd-493b-a170-011d0cc1398e"), "Warm", new DateOnly(2026, 2, 10), 0, 6.0 },
                    { new Guid("b415650c-320e-46e8-97dd-cbb9e891815f"), "Freezing", new DateOnly(2023, 7, 16), 0, 17.0 },
                    { new Guid("d75ce0bf-657e-4baf-aa21-0bb1b73cd5f8"), "Warm", new DateOnly(2025, 10, 3), 0, 29.0 },
                    { new Guid("d86b61a8-1c3a-474b-9af9-83052cc48f98"), "Mild", new DateOnly(2024, 10, 16), 0, 5.0 },
                    { new Guid("da5e3eb1-5b2f-46dc-8a0c-d1d0156f541b"), "Scorching", new DateOnly(2023, 4, 22), 0, 7.0 },
                    { new Guid("db492ae0-b851-42d6-8f59-ce69ca810538"), "Balmy", new DateOnly(2026, 1, 21), 0, 24.0 },
                    { new Guid("e4001aa6-3358-46b6-84a5-2e423ce90b94"), "Bracing", new DateOnly(2026, 9, 23), 0, -3.0 },
                    { new Guid("e9fbb1f4-4465-41ea-9816-0e2ced492072"), "Chilly", new DateOnly(2025, 3, 9), 0, 12.0 }
                });
        }
    }
}
