using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorRelationshipUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("1dc89f7b-7ccb-4b74-9789-f36223104036"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("1f321217-7a9c-4548-9d30-13ced1429b42"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("267df3bf-757a-4646-a146-7a5d23ccdfaa"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("488df78f-8f93-4bff-91e9-978cb5b5fc00"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9b66770a-c349-4360-b24b-caf4f5497697"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0e9f7c76-d842-4cac-9603-339a8abbd441"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b897db57-b761-48b6-96c8-c8723c7d5576"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0b9e2c65-a9c9-4301-a4a4-2c36d2d072f9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1136a82d-9eb8-4ab0-86f9-df6dd7ef173d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1475a3ee-87be-49ad-9792-444ed5f08347"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1dcc2fcb-0101-42df-97cc-9ac238afde57"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("25f0dad7-c4a4-4770-b40a-e75a77e56f14"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("2c854f4f-7b64-49f1-8c84-92d13c315bc3"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("34289d0b-9120-45f7-9a6e-e5a70aec49d5"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3aa97db3-52f2-439a-8898-3114cc6e86a5"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("561ba2f8-e10c-4a70-b9f5-7ac423e8bb44"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8636a7ce-b04c-4a48-bf8a-e4900e350e92"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8a9833f5-0fe4-4ad0-b21c-8413c3342192"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8d21c1cc-53ab-477c-ba8f-cd86579c1645"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9c04421e-0690-4d99-a258-cc2ad2bd9ab8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a3b1da9e-b8d2-4a57-9a63-8761f50f7e5b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b5f788df-fa5a-4596-87e9-8c7a1c6cdc91"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ca2b4171-3648-49ac-90cd-a7ba8f0ca8d1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d1719491-1580-457e-83b1-7f60b79a488a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d6d38f71-7ae4-4743-824b-578f8a2bd19e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("dac3df8b-7e6b-40d0-b4e1-953aeebbe6ea"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f3fab33b-bb0c-4f8f-82ff-4d43172107ac"));

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("9bc09ac6-863b-45df-9488-be216834e4cf"), new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274), "Can manage users", "ManageUsers", new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274) },
                    { new Guid("abc520a3-e143-4e27-ad84-994ef3fd227f"), new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274) },
                    { new Guid("ad01db8c-202b-47be-890f-d8cd06dec15a"), new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274), "Can read data", "Read", new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274) },
                    { new Guid("bc4c62a5-db85-4c9c-b16c-cfbb5263e642"), new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274), "Can modify data", "Write", new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274) },
                    { new Guid("c4a42caf-3623-4bb5-865f-e6e453c733bf"), new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 10, 12, 10, 49, 47, 745, DateTimeKind.Utc).AddTicks(274) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0c455147-d0e7-4922-89ad-d0c78348975a"), new DateTime(2024, 10, 12, 10, 49, 47, 746, DateTimeKind.Utc).AddTicks(8260), "Admin", new DateTime(2024, 10, 12, 10, 49, 47, 746, DateTimeKind.Utc).AddTicks(8260) },
                    { new Guid("43790e2a-3e88-4f9b-99dd-879737ab7bda"), new DateTime(2024, 10, 12, 10, 49, 47, 746, DateTimeKind.Utc).AddTicks(8260), "User", new DateTime(2024, 10, 12, 10, 49, 47, 746, DateTimeKind.Utc).AddTicks(8260) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("05f5783c-1d8b-4103-b65a-fe67eb617dff"), "Fahrenheit", 24.0, new DateOnly(2024, 2, 28), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7381), "Bracing", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7381) },
                    { new Guid("251de2be-f2e4-43e8-a7e5-9d0429b4527c"), "Celsius", 10.0, new DateOnly(2023, 1, 9), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7457), "Cool", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7457) },
                    { new Guid("58f1bf21-5f8c-4c99-820b-abbe9e21f0ac"), "Fahrenheit", -5.0, new DateOnly(2023, 1, 19), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7430), "Scorching", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7430) },
                    { new Guid("700c70c5-59de-4372-b017-e5c95b60c7d9"), "Fahrenheit", 22.0, new DateOnly(2026, 10, 13), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7473), "Chilly", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7473) },
                    { new Guid("812f582f-5f9d-449b-b4e6-1288c04c64a0"), "Celsius", 27.0, new DateOnly(2024, 11, 2), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7498), "Freezing", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7498) },
                    { new Guid("82185f0e-d921-410f-94a2-f19532d68412"), "Fahrenheit", 9.0, new DateOnly(2026, 3, 11), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7461), "Scorching", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7461) },
                    { new Guid("840e925a-61c2-4b40-928a-c69952fbbee9"), "Celsius", 2.0, new DateOnly(2026, 5, 31), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7479), "Unknown", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7479) },
                    { new Guid("8bf6a54a-2290-4015-8720-988e02b8d1d0"), "Celsius", -2.0, new DateOnly(2022, 4, 13), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7373), "Chilly", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7373) },
                    { new Guid("9780a369-0724-481d-a5da-9a17b61f0edc"), "Celsius", 23.0, new DateOnly(2027, 3, 15), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7355), "Balmy", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7355) },
                    { new Guid("9d914f5d-14bc-458c-9f28-c2f187ea4c57"), "Celsius", 8.0, new DateOnly(2025, 9, 29), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7452), "Balmy", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7452) },
                    { new Guid("a0c57aba-d79e-426c-8afb-5f6aba6f652f"), "Fahrenheit", 29.0, new DateOnly(2025, 7, 12), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7377), "Warm", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7377) },
                    { new Guid("ae95981b-5aea-47ed-a012-39477db6c152"), "Fahrenheit", 22.0, new DateOnly(2023, 1, 17), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7483), "Chilly", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7483) },
                    { new Guid("b9cf2657-0b94-4887-8608-f7639164bef3"), "Fahrenheit", 27.0, new DateOnly(2023, 3, 9), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7469), "Warm", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7469) },
                    { new Guid("ca3250af-ec5c-4d70-96a4-9abfc8b7d6b0"), "Celsius", 11.0, new DateOnly(2026, 11, 24), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7494), "Unknown", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7494) },
                    { new Guid("d5763e94-ce21-4247-8a4e-49dcb43a59ea"), "Fahrenheit", 5.0, new DateOnly(2023, 1, 21), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7465), "Hot", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7465) },
                    { new Guid("d6a7af4e-3d54-43ae-bbbf-42262b2c0695"), "Celsius", 26.0, new DateOnly(2026, 1, 1), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7490), "Mild", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7490) },
                    { new Guid("e43c57e7-1d86-43c0-9ab8-26832ff131ac"), "Celsius", -2.0, new DateOnly(2023, 9, 23), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7442), "Balmy", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7442) },
                    { new Guid("ed38ea80-3bac-456b-8f61-a6b1601d1070"), "Fahrenheit", 26.0, new DateOnly(2023, 4, 15), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7434), "Scorching", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7434) },
                    { new Guid("ef9b0a49-1b94-4c7b-abb6-ecec0d018acd"), "Celsius", 14.0, new DateOnly(2027, 6, 24), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7446), "Sweltering", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7446) },
                    { new Guid("feef765b-38db-4fba-ae68-3356051c05c7"), "Fahrenheit", -5.0, new DateOnly(2025, 3, 24), new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7367), "Bracing", new DateTime(2024, 10, 12, 12, 49, 47, 754, DateTimeKind.Local).AddTicks(7367) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9bc09ac6-863b-45df-9488-be216834e4cf"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("abc520a3-e143-4e27-ad84-994ef3fd227f"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ad01db8c-202b-47be-890f-d8cd06dec15a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("bc4c62a5-db85-4c9c-b16c-cfbb5263e642"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("c4a42caf-3623-4bb5-865f-e6e453c733bf"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0c455147-d0e7-4922-89ad-d0c78348975a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("43790e2a-3e88-4f9b-99dd-879737ab7bda"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("05f5783c-1d8b-4103-b65a-fe67eb617dff"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("251de2be-f2e4-43e8-a7e5-9d0429b4527c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("58f1bf21-5f8c-4c99-820b-abbe9e21f0ac"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("700c70c5-59de-4372-b017-e5c95b60c7d9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("812f582f-5f9d-449b-b4e6-1288c04c64a0"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("82185f0e-d921-410f-94a2-f19532d68412"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("840e925a-61c2-4b40-928a-c69952fbbee9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8bf6a54a-2290-4015-8720-988e02b8d1d0"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9780a369-0724-481d-a5da-9a17b61f0edc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9d914f5d-14bc-458c-9f28-c2f187ea4c57"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a0c57aba-d79e-426c-8afb-5f6aba6f652f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ae95981b-5aea-47ed-a012-39477db6c152"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b9cf2657-0b94-4887-8608-f7639164bef3"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ca3250af-ec5c-4d70-96a4-9abfc8b7d6b0"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d5763e94-ce21-4247-8a4e-49dcb43a59ea"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d6a7af4e-3d54-43ae-bbbf-42262b2c0695"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e43c57e7-1d86-43c0-9ab8-26832ff131ac"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ed38ea80-3bac-456b-8f61-a6b1601d1070"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ef9b0a49-1b94-4c7b-abb6-ecec0d018acd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("feef765b-38db-4fba-ae68-3356051c05c7"));

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1dc89f7b-7ccb-4b74-9789-f36223104036"), new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771), "Can modify data", "Write", new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771) },
                    { new Guid("1f321217-7a9c-4548-9d30-13ced1429b42"), new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771) },
                    { new Guid("267df3bf-757a-4646-a146-7a5d23ccdfaa"), new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771) },
                    { new Guid("488df78f-8f93-4bff-91e9-978cb5b5fc00"), new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771), "Can manage users", "ManageUsers", new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771) },
                    { new Guid("9b66770a-c349-4360-b24b-caf4f5497697"), new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771), "Can read data", "Read", new DateTime(2024, 10, 6, 13, 29, 36, 707, DateTimeKind.Utc).AddTicks(2771) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e9f7c76-d842-4cac-9603-339a8abbd441"), new DateTime(2024, 10, 6, 13, 29, 36, 709, DateTimeKind.Utc).AddTicks(184), "User", new DateTime(2024, 10, 6, 13, 29, 36, 709, DateTimeKind.Utc).AddTicks(184) },
                    { new Guid("b897db57-b761-48b6-96c8-c8723c7d5576"), new DateTime(2024, 10, 6, 13, 29, 36, 709, DateTimeKind.Utc).AddTicks(184), "Admin", new DateTime(2024, 10, 6, 13, 29, 36, 709, DateTimeKind.Utc).AddTicks(184) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "CreatedDate", "Summary", "UpdatedDate", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("0b9e2c65-a9c9-4301-a4a4-2c36d2d072f9"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8248), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8248), new DateOnly(2026, 10, 2), "Celsius", 22.0 },
                    { new Guid("1136a82d-9eb8-4ab0-86f9-df6dd7ef173d"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8260), "Hot", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8260), new DateOnly(2023, 2, 23), "Fahrenheit", 31.0 },
                    { new Guid("1475a3ee-87be-49ad-9792-444ed5f08347"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8128), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8128), new DateOnly(2025, 1, 2), "Fahrenheit", 31.0 },
                    { new Guid("1dcc2fcb-0101-42df-97cc-9ac238afde57"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8177), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8177), new DateOnly(2027, 5, 4), "Fahrenheit", 22.0 },
                    { new Guid("25f0dad7-c4a4-4770-b40a-e75a77e56f14"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8224), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8224), new DateOnly(2023, 3, 16), "Fahrenheit", 3.0 },
                    { new Guid("2c854f4f-7b64-49f1-8c84-92d13c315bc3"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8210), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8210), new DateOnly(2027, 3, 29), "Fahrenheit", 31.0 },
                    { new Guid("34289d0b-9120-45f7-9a6e-e5a70aec49d5"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8252), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8252), new DateOnly(2024, 6, 2), "Fahrenheit", -4.0 },
                    { new Guid("3aa97db3-52f2-439a-8898-3114cc6e86a5"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8240), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8240), new DateOnly(2023, 11, 10), "Celsius", 29.0 },
                    { new Guid("561ba2f8-e10c-4a70-b9f5-7ac423e8bb44"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8236), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8236), new DateOnly(2023, 6, 14), "Fahrenheit", 26.0 },
                    { new Guid("8636a7ce-b04c-4a48-bf8a-e4900e350e92"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8264), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8264), new DateOnly(2026, 3, 28), "Celsius", -3.0 },
                    { new Guid("8a9833f5-0fe4-4ad0-b21c-8413c3342192"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8173), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8173), new DateOnly(2025, 5, 19), "Fahrenheit", 26.0 },
                    { new Guid("8d21c1cc-53ab-477c-ba8f-cd86579c1645"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8232), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8232), new DateOnly(2023, 12, 5), "Celsius", -5.0 },
                    { new Guid("9c04421e-0690-4d99-a258-cc2ad2bd9ab8"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8244), "Cool", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8244), new DateOnly(2024, 9, 4), "Fahrenheit", 33.0 },
                    { new Guid("a3b1da9e-b8d2-4a57-9a63-8761f50f7e5b"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8228), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8228), new DateOnly(2022, 2, 5), "Fahrenheit", 8.0 },
                    { new Guid("b5f788df-fa5a-4596-87e9-8c7a1c6cdc91"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8166), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8166), new DateOnly(2023, 5, 13), "Fahrenheit", 0.0 },
                    { new Guid("ca2b4171-3648-49ac-90cd-a7ba8f0ca8d1"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8268), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8268), new DateOnly(2022, 8, 22), "Fahrenheit", 0.0 },
                    { new Guid("d1719491-1580-457e-83b1-7f60b79a488a"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8215), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8215), new DateOnly(2023, 6, 3), "Celsius", -4.0 },
                    { new Guid("d6d38f71-7ae4-4743-824b-578f8a2bd19e"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8153), "Scorching", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8153), new DateOnly(2026, 9, 6), "Fahrenheit", 12.0 },
                    { new Guid("dac3df8b-7e6b-40d0-b4e1-953aeebbe6ea"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8159), "Scorching", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8159), new DateOnly(2027, 6, 29), "Celsius", 18.0 },
                    { new Guid("f3fab33b-bb0c-4f8f-82ff-4d43172107ac"), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8162), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8162), new DateOnly(2027, 2, 27), "Fahrenheit", 27.0 }
                });
        }
    }
}
