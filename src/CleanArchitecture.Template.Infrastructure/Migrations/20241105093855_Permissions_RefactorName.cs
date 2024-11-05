using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Permissions_RefactorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4c30daa1-e676-4adb-80d4-39b89fe66b38"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5897a698-c9de-4539-891a-fafdb7cfb6b2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("798b3227-f830-4ad7-bae3-a48412f73024"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("dec0a8b0-488c-45e9-b947-610159067013"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72df50b1-b6c6-4a04-b2f5-80938ff0bbcd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("10a5461d-5f6e-421f-981b-5baee57e7b81"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("22d9980c-eced-4e6f-b640-defc605b0083"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("32084b7a-b93a-4c23-8fd4-57377de78e5b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("34a3834b-05f6-4b17-91da-ea35eb362241"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("374bd98b-d621-4d3c-b7d6-8e8d80a29cb3"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("46ff8b53-84a6-4ca5-b111-aaf70f4be516"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6325998e-c6e0-45ef-9990-73aa66952160"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6a92bfca-6597-4e58-864d-f842dc2813f4"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7e71704f-bbee-4fd3-8ba3-bb2308b820cc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("81a72c6f-f2ac-4920-a797-89b36203d88c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8519ad1d-a316-48c4-8faa-3c912e0dd6e6"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8b9b3bfe-de05-4a25-a9df-705954a23bee"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8c44ad18-bf42-4e6a-87e5-897c4fdd0c83"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9b3c23ee-0433-4774-8cdd-21c5fc0a081f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a98a1705-c525-450c-8f58-7065f4863598"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("adef71eb-e132-4a5f-ac46-8950a9ace635"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b137656c-0c66-4ec5-8ffc-66e0cce9ae8f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c6304d0a-6708-4e2d-8841-ee243a748694"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e38eb104-9460-4fe1-97b1-e7b4d64d6ae8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ea3be4a3-426c-4f96-ba39-80b05669426b"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Permissions",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "Description", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("12560448-04aa-426c-beb4-d32e37a0ff8e"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) },
                    { new Guid("56106dce-d07b-4cbf-9af4-63c3adbe4833"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Can modify data", "Write", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) },
                    { new Guid("6f281a19-6383-434c-8e51-fffb3d7b9e00"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Can read data", "Read", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) },
                    { new Guid("a2047c9d-5c51-4d00-8a1a-659ac6e8d3e6"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Can manage users", "ManageUsers", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) },
                    { new Guid("fdab3f8f-8108-40e9-b454-7e51cdf895f0"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) }
                });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("6f281a19-6383-434c-8e51-fffb3d7b9e00"), new Guid("f43167dd-07a8-427d-bb45-d881e121b22c") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("56106dce-d07b-4cbf-9af4-63c3adbe4833"), new Guid("f43167dd-07a8-427d-bb45-d881e121b22c") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("a2047c9d-5c51-4d00-8a1a-659ac6e8d3e6"), new Guid("f43167dd-07a8-427d-bb45-d881e121b22c") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("fdab3f8f-8108-40e9-b454-7e51cdf895f0"), new Guid("f43167dd-07a8-427d-bb45-d881e121b22c") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("12560448-04aa-426c-beb4-d32e37a0ff8e"), new Guid("f43167dd-07a8-427d-bb45-d881e121b22c") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("6f281a19-6383-434c-8e51-fffb3d7b9e00"), new Guid("1a4f9529-c954-4738-9bdf-41c928adda60") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1a4f9529-c954-4738-9bdf-41c928adda60"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "User", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) },
                    { new Guid("f43167dd-07a8-427d-bb45-d881e121b22c"), new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186), "Admin", new DateTime(2024, 11, 5, 9, 38, 55, 108, DateTimeKind.Utc).AddTicks(5186) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0967743a-ff3f-4a01-ab76-7f36de59b549"), "Celsius", 13.0, new DateOnly(2026, 6, 18), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(2933), "Warm", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(2933) },
                    { new Guid("2f4050dc-144d-464e-adcf-a2932805d70e"), "Fahrenheit", -2.0, new DateOnly(2022, 7, 30), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3328), "Freezing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3328) },
                    { new Guid("35d88bae-1d0f-41d0-907b-a1275b0d2e56"), "Fahrenheit", 34.0, new DateOnly(2025, 10, 1), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3051), "Mild", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3051) },
                    { new Guid("3a5af1b0-0f3e-40a2-992c-812f3c8f398b"), "Celsius", 5.0, new DateOnly(2025, 2, 4), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3316), "Freezing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3316) },
                    { new Guid("3f8f56ac-e67b-4f28-af68-dc99b570fd4d"), "Celsius", 4.0, new DateOnly(2027, 5, 30), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3321), "Bracing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3321) },
                    { new Guid("40e7f626-55a7-49a5-9573-648382c56c0b"), "Fahrenheit", 8.0, new DateOnly(2026, 11, 14), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3260), "Sweltering", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3260) },
                    { new Guid("47972eea-1161-4e91-8e6c-c96cc2e5f23d"), "Celsius", 19.0, new DateOnly(2026, 1, 8), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3034), "Scorching", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3034) },
                    { new Guid("51c039d2-2855-48f1-8e11-376e9cdd29b8"), "Celsius", 6.0, new DateOnly(2026, 8, 10), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3046), "Chilly", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3046) },
                    { new Guid("5ea60fd9-899c-4518-a7f0-acd3168ae130"), "Fahrenheit", 23.0, new DateOnly(2026, 7, 4), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3300), "Unknown", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3300) },
                    { new Guid("6cef9497-e904-421d-ad37-d90e59a0d236"), "Fahrenheit", 15.0, new DateOnly(2022, 7, 29), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3295), "Scorching", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3295) },
                    { new Guid("6e50f4f5-05a1-4a1c-8404-b5d9fa681f1a"), "Celsius", 14.0, new DateOnly(2024, 6, 18), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3336), "Unknown", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3336) },
                    { new Guid("913d71e2-41f6-4a12-9763-c7cf64921432"), "Celsius", 31.0, new DateOnly(2025, 9, 21), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3305), "Chilly", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3305) },
                    { new Guid("95bcd318-836a-44e5-aff3-0905c2638c25"), "Celsius", 30.0, new DateOnly(2025, 7, 13), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(2970), "Bracing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(2970) },
                    { new Guid("ad47fae2-83df-4ae8-bb1a-0a4cb4e4f845"), "Fahrenheit", 15.0, new DateOnly(2023, 1, 9), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3289), "Hot", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3289) },
                    { new Guid("b0dc56e2-eb02-4ddd-beb9-e9f94156713d"), "Fahrenheit", 15.0, new DateOnly(2026, 6, 7), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3264), "Warm", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3264) },
                    { new Guid("cbbb7b93-6b09-4547-9245-2272372e81ac"), "Celsius", 13.0, new DateOnly(2024, 6, 12), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3023), "Balmy", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3023) },
                    { new Guid("dfb40841-019a-4343-82a0-c6cfe2ea57c8"), "Fahrenheit", -3.0, new DateOnly(2022, 11, 10), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3341), "Bracing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3341) },
                    { new Guid("e79d2f06-ebd4-48d1-8609-e6e3429071bd"), "Fahrenheit", -3.0, new DateOnly(2027, 4, 19), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3310), "Unknown", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3310) },
                    { new Guid("eb5d3158-1283-4ea5-ad04-012decd5dc04"), "Fahrenheit", 16.0, new DateOnly(2025, 1, 6), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3029), "Bracing", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3029) },
                    { new Guid("ed11fe4e-c827-4056-8d95-18c34f25b8f0"), "Fahrenheit", 27.0, new DateOnly(2027, 6, 12), new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3280), "Cool", new DateTime(2024, 11, 5, 10, 38, 55, 108, DateTimeKind.Local).AddTicks(3280) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("12560448-04aa-426c-beb4-d32e37a0ff8e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("56106dce-d07b-4cbf-9af4-63c3adbe4833"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6f281a19-6383-434c-8e51-fffb3d7b9e00"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a2047c9d-5c51-4d00-8a1a-659ac6e8d3e6"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fdab3f8f-8108-40e9-b454-7e51cdf895f0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1a4f9529-c954-4738-9bdf-41c928adda60"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f43167dd-07a8-427d-bb45-d881e121b22c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0967743a-ff3f-4a01-ab76-7f36de59b549"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("2f4050dc-144d-464e-adcf-a2932805d70e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("35d88bae-1d0f-41d0-907b-a1275b0d2e56"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3a5af1b0-0f3e-40a2-992c-812f3c8f398b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3f8f56ac-e67b-4f28-af68-dc99b570fd4d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("40e7f626-55a7-49a5-9573-648382c56c0b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("47972eea-1161-4e91-8e6c-c96cc2e5f23d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("51c039d2-2855-48f1-8e11-376e9cdd29b8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5ea60fd9-899c-4518-a7f0-acd3168ae130"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6cef9497-e904-421d-ad37-d90e59a0d236"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6e50f4f5-05a1-4a1c-8404-b5d9fa681f1a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("913d71e2-41f6-4a12-9763-c7cf64921432"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("95bcd318-836a-44e5-aff3-0905c2638c25"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ad47fae2-83df-4ae8-bb1a-0a4cb4e4f845"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b0dc56e2-eb02-4ddd-beb9-e9f94156713d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("cbbb7b93-6b09-4547-9245-2272372e81ac"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("dfb40841-019a-4343-82a0-c6cfe2ea57c8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e79d2f06-ebd4-48d1-8609-e6e3429071bd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("eb5d3158-1283-4ea5-ad04-012decd5dc04"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ed11fe4e-c827-4056-8d95-18c34f25b8f0"));

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Permissions",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can read data", "Read", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("4c30daa1-e676-4adb-80d4-39b89fe66b38"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("5897a698-c9de-4539-891a-fafdb7cfb6b2"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("798b3227-f830-4ad7-bae3-a48412f73024"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can manage users", "ManageUsers", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("dec0a8b0-488c-45e9-b947-610159067013"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can modify data", "Write", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) }
                });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("dec0a8b0-488c-45e9-b947-610159067013"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("798b3227-f830-4ad7-bae3-a48412f73024"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("5897a698-c9de-4539-891a-fafdb7cfb6b2"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("4c30daa1-e676-4adb-80d4-39b89fe66b38"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new Guid("72df50b1-b6c6-4a04-b2f5-80938ff0bbcd") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("72df50b1-b6c6-4a04-b2f5-80938ff0bbcd"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "User", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Admin", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "CreatedDate", "Summary", "UpdatedDate", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("10a5461d-5f6e-421f-981b-5baee57e7b81"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4682), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4682), new DateOnly(2022, 12, 15), "Celsius", 31.0 },
                    { new Guid("22d9980c-eced-4e6f-b640-defc605b0083"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4661), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4661), new DateOnly(2024, 6, 13), "Fahrenheit", -5.0 },
                    { new Guid("32084b7a-b93a-4c23-8fd4-57377de78e5b"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4595), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4595), new DateOnly(2022, 11, 26), "Celsius", 15.0 },
                    { new Guid("34a3834b-05f6-4b17-91da-ea35eb362241"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4655), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4655), new DateOnly(2025, 5, 13), "Fahrenheit", 28.0 },
                    { new Guid("374bd98b-d621-4d3c-b7d6-8e8d80a29cb3"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4678), "Hot", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4678), new DateOnly(2026, 10, 13), "Fahrenheit", 16.0 },
                    { new Guid("46ff8b53-84a6-4ca5-b111-aaf70f4be516"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4642), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4642), new DateOnly(2024, 5, 29), "Celsius", 27.0 },
                    { new Guid("6325998e-c6e0-45ef-9990-73aa66952160"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4636), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4636), new DateOnly(2026, 3, 13), "Fahrenheit", -1.0 },
                    { new Guid("6a92bfca-6597-4e58-864d-f842dc2813f4"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4618), "Scorching", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4618), new DateOnly(2027, 1, 17), "Fahrenheit", 13.0 },
                    { new Guid("7e71704f-bbee-4fd3-8ba3-bb2308b820cc"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4614), "Sweltering", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4614), new DateOnly(2026, 10, 28), "Fahrenheit", 23.0 },
                    { new Guid("81a72c6f-f2ac-4920-a797-89b36203d88c"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4652), "Bracing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4652), new DateOnly(2026, 1, 27), "Fahrenheit", 18.0 },
                    { new Guid("8519ad1d-a316-48c4-8faa-3c912e0dd6e6"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4685), "Balmy", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4685), new DateOnly(2023, 10, 14), "Celsius", 8.0 },
                    { new Guid("8b9b3bfe-de05-4a25-a9df-705954a23bee"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4629), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4629), new DateOnly(2023, 1, 29), "Fahrenheit", 17.0 },
                    { new Guid("8c44ad18-bf42-4e6a-87e5-897c4fdd0c83"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4673), "Scorching", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4673), new DateOnly(2024, 8, 8), "Fahrenheit", -1.0 },
                    { new Guid("9b3c23ee-0433-4774-8cdd-21c5fc0a081f"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4621), "Unknown", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4621), new DateOnly(2022, 12, 26), "Celsius", 28.0 },
                    { new Guid("a98a1705-c525-450c-8f58-7065f4863598"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4609), "Sweltering", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4609), new DateOnly(2023, 11, 20), "Celsius", -1.0 },
                    { new Guid("adef71eb-e132-4a5f-ac46-8950a9ace635"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4668), "Freezing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4668), new DateOnly(2026, 6, 23), "Celsius", 24.0 },
                    { new Guid("b137656c-0c66-4ec5-8ffc-66e0cce9ae8f"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4664), "Balmy", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4664), new DateOnly(2026, 5, 14), "Celsius", 19.0 },
                    { new Guid("c6304d0a-6708-4e2d-8841-ee243a748694"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4648), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4648), new DateOnly(2023, 5, 9), "Celsius", -4.0 },
                    { new Guid("e38eb104-9460-4fe1-97b1-e7b4d64d6ae8"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4658), "Freezing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4658), new DateOnly(2025, 6, 28), "Celsius", -2.0 },
                    { new Guid("ea3be4a3-426c-4f96-ba39-80b05669426b"), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4632), "Hot", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4632), new DateOnly(2024, 5, 30), "Fahrenheit", 31.0 }
                });
        }
    }
}
