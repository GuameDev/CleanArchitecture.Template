using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultDataUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "Description", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) },
                    { new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Can read data", "Read", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) },
                    { new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Can modify data", "Write", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) },
                    { new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Can manage users", "ManageUsers", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) },
                    { new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "Admin", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) },
                    { new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349), "User", new DateTime(2024, 11, 23, 14, 40, 45, 885, DateTimeKind.Utc).AddTicks(7349) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("15f69804-102f-4deb-8177-e3aed318eb52"), "Celsius", 4.0, new DateOnly(2025, 11, 8), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6528), "Freezing", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6528) },
                    { new Guid("23d383ca-bcea-47ae-ad65-b852e766d974"), "Celsius", 13.0, new DateOnly(2023, 10, 13), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6500), "Mild", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6500) },
                    { new Guid("244dbca0-5cf0-4524-bd29-876f2fa728ca"), "Fahrenheit", 27.0, new DateOnly(2022, 10, 15), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6573), "Balmy", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6573) },
                    { new Guid("31fb0ae4-7ce8-46ee-84e8-df09ffaccd37"), "Celsius", 24.0, new DateOnly(2026, 7, 1), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6595), "Cool", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6595) },
                    { new Guid("36a7d6f1-feb4-47bd-b75f-ec1bfe8070c6"), "Celsius", 23.0, new DateOnly(2026, 12, 9), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6509), "Mild", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6509) },
                    { new Guid("39f15b17-02f7-48cc-9b02-39a03c1bc40e"), "Celsius", 32.0, new DateOnly(2026, 6, 26), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6551), "Sweltering", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6551) },
                    { new Guid("4de14420-e315-4dd5-b41b-689458e38525"), "Celsius", -5.0, new DateOnly(2026, 7, 25), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6617), "Cool", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6617) },
                    { new Guid("55118d7f-40d5-4e77-9c75-0458c609ee78"), "Celsius", 0.0, new DateOnly(2022, 11, 7), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6516), "Warm", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6516) },
                    { new Guid("65f0a12e-df77-4180-bdce-6c4550c8f079"), "Celsius", 3.0, new DateOnly(2026, 2, 19), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6562), "Sweltering", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6562) },
                    { new Guid("706e77b8-b873-441a-b177-2c9b7597cb29"), "Fahrenheit", 9.0, new DateOnly(2027, 4, 7), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6676), "Scorching", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6676) },
                    { new Guid("907b936d-2f36-4a8a-8acf-220636b15357"), "Fahrenheit", 16.0, new DateOnly(2026, 9, 10), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6535), "Sweltering", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6535) },
                    { new Guid("92ea0dda-2e21-40bd-8947-6eec20423b97"), "Celsius", 8.0, new DateOnly(2025, 10, 16), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6602), "Chilly", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6602) },
                    { new Guid("a55af980-03ed-4910-8f66-15c54d64ff10"), "Fahrenheit", -5.0, new DateOnly(2022, 5, 16), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6694), "Hot", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6694) },
                    { new Guid("a74e1219-36f9-4ba8-9397-73829d9ef927"), "Celsius", 17.0, new DateOnly(2024, 4, 2), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6588), "Bracing", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6588) },
                    { new Guid("ade5f359-4e2c-4fb1-86c0-8b6e5de2c689"), "Fahrenheit", 9.0, new DateOnly(2022, 6, 21), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6543), "Balmy", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6543) },
                    { new Guid("bee635eb-f266-481a-9239-4a14b20c3039"), "Fahrenheit", -5.0, new DateOnly(2022, 11, 18), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6473), "Warm", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6473) },
                    { new Guid("c38493b7-80a9-4367-9870-253b54c002d8"), "Fahrenheit", 18.0, new DateOnly(2022, 11, 15), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6451), "Hot", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6451) },
                    { new Guid("c81b8eb9-48d7-4591-8103-560e99092b3e"), "Fahrenheit", -4.0, new DateOnly(2027, 4, 22), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6687), "Mild", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6687) },
                    { new Guid("e0aa1aa0-5f9e-4863-9ca4-1dbfb04561f2"), "Celsius", 0.0, new DateOnly(2027, 7, 20), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6610), "Balmy", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6610) },
                    { new Guid("e608a367-6244-4186-a379-dc2f38eeedd6"), "Celsius", 7.0, new DateOnly(2022, 3, 7), new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6581), "Bracing", new DateTime(2024, 11, 23, 15, 40, 45, 885, DateTimeKind.Local).AddTicks(6581) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c") },
                    { 2, new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c") },
                    { 3, new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c") },
                    { 4, new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"), new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c") },
                    { 5, new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"), new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c") },
                    { 6, new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("15f69804-102f-4deb-8177-e3aed318eb52"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("23d383ca-bcea-47ae-ad65-b852e766d974"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("244dbca0-5cf0-4524-bd29-876f2fa728ca"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("31fb0ae4-7ce8-46ee-84e8-df09ffaccd37"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("36a7d6f1-feb4-47bd-b75f-ec1bfe8070c6"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("39f15b17-02f7-48cc-9b02-39a03c1bc40e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4de14420-e315-4dd5-b41b-689458e38525"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("55118d7f-40d5-4e77-9c75-0458c609ee78"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("65f0a12e-df77-4180-bdce-6c4550c8f079"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("706e77b8-b873-441a-b177-2c9b7597cb29"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("907b936d-2f36-4a8a-8acf-220636b15357"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("92ea0dda-2e21-40bd-8947-6eec20423b97"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a55af980-03ed-4910-8f66-15c54d64ff10"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a74e1219-36f9-4ba8-9397-73829d9ef927"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ade5f359-4e2c-4fb1-86c0-8b6e5de2c689"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bee635eb-f266-481a-9239-4a14b20c3039"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c38493b7-80a9-4367-9870-253b54c002d8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c81b8eb9-48d7-4591-8103-560e99092b3e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e0aa1aa0-5f9e-4863-9ca4-1dbfb04561f2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e608a367-6244-4186-a379-dc2f38eeedd6"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "CreatedDate", "Summary", "UpdatedDate", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("0c1cec78-ea45-444b-a500-8fc7761a4fe1"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(404), "Scorching", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(404), new DateOnly(2023, 11, 24), "Celsius", 20.0 },
                    { new Guid("0d02b865-28c7-40ca-91ce-14155cfc02bd"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(503), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(503), new DateOnly(2024, 3, 30), "Fahrenheit", 15.0 },
                    { new Guid("15593239-e01d-4dd9-b9a5-5074c08ce3ad"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(499), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(499), new DateOnly(2023, 9, 12), "Fahrenheit", 17.0 },
                    { new Guid("157d9d0e-329f-4a40-94da-a79ab5fe9b69"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(440), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(440), new DateOnly(2026, 9, 7), "Fahrenheit", -5.0 },
                    { new Guid("1d428048-92f0-42cd-a381-0c12acc5dc61"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(435), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(435), new DateOnly(2023, 3, 18), "Fahrenheit", 14.0 },
                    { new Guid("25798d45-d9ac-48c1-8e96-46b184ebbedd"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(428), "Unknown", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(428), new DateOnly(2024, 1, 10), "Celsius", 17.0 },
                    { new Guid("270b6a65-eaee-4a49-8a41-f15ba0a093e8"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(415), "Sweltering", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(415), new DateOnly(2022, 3, 18), "Fahrenheit", 29.0 },
                    { new Guid("4d27b960-5474-40b1-9f24-7ff3eb02cf04"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(524), "Freezing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(524), new DateOnly(2025, 8, 6), "Celsius", 16.0 },
                    { new Guid("546cf3bb-268d-4446-ae25-6240bb0cfbaf"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(508), "Balmy", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(508), new DateOnly(2022, 6, 6), "Fahrenheit", 4.0 },
                    { new Guid("646b86ee-9ddc-41ab-b562-d38c53c2280b"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(489), "Scorching", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(489), new DateOnly(2023, 10, 10), "Celsius", -3.0 },
                    { new Guid("6e456178-6db8-425b-9bfc-de9ccad22c7d"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(478), "Warm", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(478), new DateOnly(2023, 7, 31), "Fahrenheit", 4.0 },
                    { new Guid("760faed7-de9f-4d31-9f5f-6ead04862b4e"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(420), "Mild", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(420), new DateOnly(2025, 6, 4), "Fahrenheit", 3.0 },
                    { new Guid("8273e1bd-fc99-47f3-805b-f7a7290a7c8c"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(410), "Hot", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(410), new DateOnly(2025, 4, 8), "Fahrenheit", 3.0 },
                    { new Guid("8712d094-a4bf-4abf-974d-d3b7fa881d52"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(393), "Mild", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(393), new DateOnly(2023, 12, 31), "Fahrenheit", -1.0 },
                    { new Guid("8e85b4b9-88ac-4bc8-8692-d7b1ef1f039e"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(515), "Cool", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(515), new DateOnly(2027, 6, 13), "Celsius", 18.0 },
                    { new Guid("9381fdc9-2d64-4afb-ad17-7b70eb44e1d5"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(532), "Cool", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(532), new DateOnly(2024, 5, 18), "Fahrenheit", 0.0 },
                    { new Guid("b1e542bd-1323-473b-9d07-d2cd2786fa5b"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(494), "Hot", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(494), new DateOnly(2027, 3, 23), "Celsius", 6.0 },
                    { new Guid("bcd9b555-55bb-4e3b-b0a7-8c5d285443b1"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(519), "Chilly", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(519), new DateOnly(2027, 3, 23), "Celsius", -5.0 },
                    { new Guid("cf2f9cbc-0b30-46b9-9ad5-c7fc50130f58"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(541), "Bracing", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(541), new DateOnly(2022, 10, 12), "Celsius", -1.0 },
                    { new Guid("fb2c192f-e32c-477e-b736-3049586fdb92"), new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(536), "Balmy", new DateTime(2024, 11, 23, 15, 40, 8, 986, DateTimeKind.Local).AddTicks(536), new DateOnly(2023, 7, 8), "Celsius", 13.0 }
                });
        }
    }
}
