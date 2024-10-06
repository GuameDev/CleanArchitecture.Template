using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_UserId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("2e2b887b-0906-4b87-a2fd-5b54393c6a71"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("32cc229b-6b25-44d8-b1c1-cbb1361a2717"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b626ba6b-eab3-4fac-92e4-9a95a752d704"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("bb31e5ce-3570-49ea-810d-fc97841461bf"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("cdb142f6-8166-4033-993b-7115c9e20397"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("41234080-f21a-4a44-8516-2dae646aa123"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8f308976-de9f-4db5-a560-a7a8ad0bfa62"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("135132dd-f7b1-40c9-bbc7-4e61e30d273a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("19731922-706c-4435-b5b0-705e3d06646c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("27982c20-7f3e-4a94-b7d6-dd6d6bd9696d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3d3e3562-3e0f-458c-bc51-71fc7cfc9dad"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4b3aa17c-2f32-4bb8-a5c7-ba23048456bd"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("59c2e145-ec24-45a8-b3ec-49d804b4c2b7"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5a26f595-d010-4fa8-8363-9dbc4d0cc128"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5af0d73e-2f0a-4388-8bab-9a7f253abf88"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5d5b86eb-3ec1-47a1-b0aa-0a3c1b567a3e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6ca8b6a6-afee-4028-9570-491f28568d97"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("875efc10-25a9-4437-9a19-0f9a08122c0d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a8505e56-cb52-4f77-9f7c-bfbe1aca9d1e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("acce7e5f-be19-41ad-b2ae-542647fcb201"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b6f5f446-af71-4efc-a17d-f81bf3a62415"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bc991811-6dee-4b4d-a575-ac0669f11bc7"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c88b0388-cd42-4117-b310-bb0e4157b543"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d7ee4b75-1ea7-4c77-a17e-c59371120a96"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e7d9a120-4f43-4b3d-a973-e47146d77d14"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ebf7d842-8645-4f97-8fd8-35b69c1f573c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("fac83a78-8db7-4677-b8d4-176bea9881a3"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Role");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0b9e2c65-a9c9-4301-a4a4-2c36d2d072f9"), "Celsius", 22.0, new DateOnly(2026, 10, 2), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8248), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8248) },
                    { new Guid("1136a82d-9eb8-4ab0-86f9-df6dd7ef173d"), "Fahrenheit", 31.0, new DateOnly(2023, 2, 23), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8260), "Hot", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8260) },
                    { new Guid("1475a3ee-87be-49ad-9792-444ed5f08347"), "Fahrenheit", 31.0, new DateOnly(2025, 1, 2), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8128), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8128) },
                    { new Guid("1dcc2fcb-0101-42df-97cc-9ac238afde57"), "Fahrenheit", 22.0, new DateOnly(2027, 5, 4), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8177), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8177) },
                    { new Guid("25f0dad7-c4a4-4770-b40a-e75a77e56f14"), "Fahrenheit", 3.0, new DateOnly(2023, 3, 16), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8224), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8224) },
                    { new Guid("2c854f4f-7b64-49f1-8c84-92d13c315bc3"), "Fahrenheit", 31.0, new DateOnly(2027, 3, 29), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8210), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8210) },
                    { new Guid("34289d0b-9120-45f7-9a6e-e5a70aec49d5"), "Fahrenheit", -4.0, new DateOnly(2024, 6, 2), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8252), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8252) },
                    { new Guid("3aa97db3-52f2-439a-8898-3114cc6e86a5"), "Celsius", 29.0, new DateOnly(2023, 11, 10), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8240), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8240) },
                    { new Guid("561ba2f8-e10c-4a70-b9f5-7ac423e8bb44"), "Fahrenheit", 26.0, new DateOnly(2023, 6, 14), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8236), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8236) },
                    { new Guid("8636a7ce-b04c-4a48-bf8a-e4900e350e92"), "Celsius", -3.0, new DateOnly(2026, 3, 28), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8264), "Freezing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8264) },
                    { new Guid("8a9833f5-0fe4-4ad0-b21c-8413c3342192"), "Fahrenheit", 26.0, new DateOnly(2025, 5, 19), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8173), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8173) },
                    { new Guid("8d21c1cc-53ab-477c-ba8f-cd86579c1645"), "Celsius", -5.0, new DateOnly(2023, 12, 5), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8232), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8232) },
                    { new Guid("9c04421e-0690-4d99-a258-cc2ad2bd9ab8"), "Fahrenheit", 33.0, new DateOnly(2024, 9, 4), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8244), "Cool", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8244) },
                    { new Guid("a3b1da9e-b8d2-4a57-9a63-8761f50f7e5b"), "Fahrenheit", 8.0, new DateOnly(2022, 2, 5), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8228), "Warm", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8228) },
                    { new Guid("b5f788df-fa5a-4596-87e9-8c7a1c6cdc91"), "Fahrenheit", 0.0, new DateOnly(2023, 5, 13), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8166), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8166) },
                    { new Guid("ca2b4171-3648-49ac-90cd-a7ba8f0ca8d1"), "Fahrenheit", 0.0, new DateOnly(2022, 8, 22), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8268), "Bracing", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8268) },
                    { new Guid("d1719491-1580-457e-83b1-7f60b79a488a"), "Celsius", -4.0, new DateOnly(2023, 6, 3), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8215), "Chilly", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8215) },
                    { new Guid("d6d38f71-7ae4-4743-824b-578f8a2bd19e"), "Fahrenheit", 12.0, new DateOnly(2026, 9, 6), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8153), "Scorching", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8153) },
                    { new Guid("dac3df8b-7e6b-40d0-b4e1-953aeebbe6ea"), "Celsius", 18.0, new DateOnly(2027, 6, 29), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8159), "Scorching", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8159) },
                    { new Guid("f3fab33b-bb0c-4f8f-82ff-4d43172107ac"), "Fahrenheit", 27.0, new DateOnly(2027, 2, 27), new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8162), "Unknown", new DateTime(2024, 10, 6, 15, 29, 36, 715, DateTimeKind.Local).AddTicks(8162) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2e2b887b-0906-4b87-a2fd-5b54393c6a71"), new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266), "Can modify data", "Write", new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266) },
                    { new Guid("32cc229b-6b25-44d8-b1c1-cbb1361a2717"), new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266) },
                    { new Guid("b626ba6b-eab3-4fac-92e4-9a95a752d704"), new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266), "Can manage users", "ManageUsers", new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266) },
                    { new Guid("bb31e5ce-3570-49ea-810d-fc97841461bf"), new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266), "Can read data", "Read", new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266) },
                    { new Guid("cdb142f6-8166-4033-993b-7115c9e20397"), new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 10, 6, 13, 21, 53, 527, DateTimeKind.Utc).AddTicks(3266) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("41234080-f21a-4a44-8516-2dae646aa123"), new DateTime(2024, 10, 6, 13, 21, 53, 530, DateTimeKind.Utc).AddTicks(4365), "Admin", new DateTime(2024, 10, 6, 13, 21, 53, 530, DateTimeKind.Utc).AddTicks(4365), null },
                    { new Guid("8f308976-de9f-4db5-a560-a7a8ad0bfa62"), new DateTime(2024, 10, 6, 13, 21, 53, 530, DateTimeKind.Utc).AddTicks(4365), "User", new DateTime(2024, 10, 6, 13, 21, 53, 530, DateTimeKind.Utc).AddTicks(4365), null }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "CreatedDate", "Summary", "UpdatedDate", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("135132dd-f7b1-40c9-bbc7-4e61e30d273a"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6100), "Hot", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6100), new DateOnly(2027, 1, 29), "Fahrenheit", 1.0 },
                    { new Guid("19731922-706c-4435-b5b0-705e3d06646c"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6233), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6233), new DateOnly(2024, 6, 18), "Fahrenheit", 27.0 },
                    { new Guid("27982c20-7f3e-4a94-b7d6-dd6d6bd9696d"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6196), "Warm", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6196), new DateOnly(2023, 4, 23), "Celsius", 0.0 },
                    { new Guid("3d3e3562-3e0f-458c-bc51-71fc7cfc9dad"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6116), "Warm", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6116), new DateOnly(2024, 4, 15), "Celsius", 31.0 },
                    { new Guid("4b3aa17c-2f32-4bb8-a5c7-ba23048456bd"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6073), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6073), new DateOnly(2026, 5, 26), "Fahrenheit", 6.0 },
                    { new Guid("59c2e145-ec24-45a8-b3ec-49d804b4c2b7"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6047), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6047), new DateOnly(2024, 7, 28), "Celsius", 7.0 },
                    { new Guid("5a26f595-d010-4fa8-8363-9dbc4d0cc128"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6065), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6065), new DateOnly(2027, 6, 8), "Fahrenheit", 0.0 },
                    { new Guid("5af0d73e-2f0a-4388-8bab-9a7f253abf88"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6211), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6211), new DateOnly(2024, 1, 4), "Celsius", 33.0 },
                    { new Guid("5d5b86eb-3ec1-47a1-b0aa-0a3c1b567a3e"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6218), "Freezing", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6218), new DateOnly(2023, 8, 22), "Fahrenheit", 20.0 },
                    { new Guid("6ca8b6a6-afee-4028-9570-491f28568d97"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6265), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6265), new DateOnly(2026, 5, 25), "Celsius", 26.0 },
                    { new Guid("875efc10-25a9-4437-9a19-0f9a08122c0d"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6258), "Scorching", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6258), new DateOnly(2026, 4, 13), "Celsius", 34.0 },
                    { new Guid("a8505e56-cb52-4f77-9f7c-bfbe1aca9d1e"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6227), "Scorching", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6227), new DateOnly(2024, 4, 21), "Celsius", 1.0 },
                    { new Guid("acce7e5f-be19-41ad-b2ae-542647fcb201"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6124), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6124), new DateOnly(2024, 5, 8), "Celsius", 5.0 },
                    { new Guid("b6f5f446-af71-4efc-a17d-f81bf3a62415"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6240), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6240), new DateOnly(2023, 6, 19), "Celsius", 14.0 },
                    { new Guid("bc991811-6dee-4b4d-a575-ac0669f11bc7"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6086), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6086), new DateOnly(2026, 12, 26), "Fahrenheit", 34.0 },
                    { new Guid("c88b0388-cd42-4117-b310-bb0e4157b543"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6109), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6109), new DateOnly(2024, 2, 5), "Fahrenheit", 8.0 },
                    { new Guid("d7ee4b75-1ea7-4c77-a17e-c59371120a96"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6080), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6080), new DateOnly(2024, 1, 21), "Fahrenheit", 1.0 },
                    { new Guid("e7d9a120-4f43-4b3d-a973-e47146d77d14"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6203), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6203), new DateOnly(2027, 6, 2), "Fahrenheit", 33.0 },
                    { new Guid("ebf7d842-8645-4f97-8fd8-35b69c1f573c"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6188), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6188), new DateOnly(2026, 12, 13), "Celsius", 12.0 },
                    { new Guid("fac83a78-8db7-4677-b8d4-176bea9881a3"), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6251), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6251), new DateOnly(2026, 5, 3), "Celsius", 13.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_UserId",
                table: "Role",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
