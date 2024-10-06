using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("00a63995-a7e4-42b2-8408-a31f5fc8abbf"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0851bbdc-cf71-4009-9ba2-d4b1020e4aa8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("19775645-82a7-4f10-917d-5a1e82c403f2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("28259e9d-fa7d-4915-baa7-85cba9ca31d2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("30eeeaee-12b4-4176-88a5-0045e32bcb6b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4583e970-640c-409b-85eb-8bd5fb84ae4d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4c1ba407-415e-4894-a489-d1f9541ea658"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4e844bd9-f72d-41ea-9939-713fe9198b20"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5229527d-cea0-43a2-b14f-3e714bb6e0fb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("831d8fda-64ce-414b-8ecc-1a90dc9f51ad"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("834debb2-fd24-4b4f-8c5a-11f0a9926976"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9aec4c12-0917-43e7-ac68-30b76b473b54"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9c7212f2-28b4-4ef2-bb15-16d60b9863eb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b4315a8a-af9f-4966-ab77-c6bce7dbfc27"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b7ee5b3a-e2ef-4aa5-9fe1-e9bac4f46ab2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bdea3223-7e74-42dc-9daa-90602e60e403"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c46f97e2-8b6c-4c67-97d5-b9224c374cee"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c7d15f40-1ac1-4b53-a0e5-7401aa095687"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("cd25b402-d580-46e4-b3fa-f0ccd4d0c34c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e709a49a-2ca8-418f-bad4-3aa58f0041e1"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "WeatherForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "WeatherForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("135132dd-f7b1-40c9-bbc7-4e61e30d273a"), "Fahrenheit", 1.0, new DateOnly(2027, 1, 29), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6100), "Hot", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6100) },
                    { new Guid("19731922-706c-4435-b5b0-705e3d06646c"), "Fahrenheit", 27.0, new DateOnly(2024, 6, 18), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6233), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6233) },
                    { new Guid("27982c20-7f3e-4a94-b7d6-dd6d6bd9696d"), "Celsius", 0.0, new DateOnly(2023, 4, 23), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6196), "Warm", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6196) },
                    { new Guid("3d3e3562-3e0f-458c-bc51-71fc7cfc9dad"), "Celsius", 31.0, new DateOnly(2024, 4, 15), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6116), "Warm", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6116) },
                    { new Guid("4b3aa17c-2f32-4bb8-a5c7-ba23048456bd"), "Fahrenheit", 6.0, new DateOnly(2026, 5, 26), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6073), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6073) },
                    { new Guid("59c2e145-ec24-45a8-b3ec-49d804b4c2b7"), "Celsius", 7.0, new DateOnly(2024, 7, 28), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6047), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6047) },
                    { new Guid("5a26f595-d010-4fa8-8363-9dbc4d0cc128"), "Fahrenheit", 0.0, new DateOnly(2027, 6, 8), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6065), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6065) },
                    { new Guid("5af0d73e-2f0a-4388-8bab-9a7f253abf88"), "Celsius", 33.0, new DateOnly(2024, 1, 4), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6211), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6211) },
                    { new Guid("5d5b86eb-3ec1-47a1-b0aa-0a3c1b567a3e"), "Fahrenheit", 20.0, new DateOnly(2023, 8, 22), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6218), "Freezing", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6218) },
                    { new Guid("6ca8b6a6-afee-4028-9570-491f28568d97"), "Celsius", 26.0, new DateOnly(2026, 5, 25), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6265), "Sweltering", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6265) },
                    { new Guid("875efc10-25a9-4437-9a19-0f9a08122c0d"), "Celsius", 34.0, new DateOnly(2026, 4, 13), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6258), "Scorching", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6258) },
                    { new Guid("a8505e56-cb52-4f77-9f7c-bfbe1aca9d1e"), "Celsius", 1.0, new DateOnly(2024, 4, 21), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6227), "Scorching", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6227) },
                    { new Guid("acce7e5f-be19-41ad-b2ae-542647fcb201"), "Celsius", 5.0, new DateOnly(2024, 5, 8), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6124), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6124) },
                    { new Guid("b6f5f446-af71-4efc-a17d-f81bf3a62415"), "Celsius", 14.0, new DateOnly(2023, 6, 19), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6240), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6240) },
                    { new Guid("bc991811-6dee-4b4d-a575-ac0669f11bc7"), "Fahrenheit", 34.0, new DateOnly(2026, 12, 26), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6086), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6086) },
                    { new Guid("c88b0388-cd42-4117-b310-bb0e4157b543"), "Fahrenheit", 8.0, new DateOnly(2024, 2, 5), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6109), "Cool", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6109) },
                    { new Guid("d7ee4b75-1ea7-4c77-a17e-c59371120a96"), "Fahrenheit", 1.0, new DateOnly(2024, 1, 21), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6080), "Unknown", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6080) },
                    { new Guid("e7d9a120-4f43-4b3d-a973-e47146d77d14"), "Fahrenheit", 33.0, new DateOnly(2027, 6, 2), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6203), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6203) },
                    { new Guid("ebf7d842-8645-4f97-8fd8-35b69c1f573c"), "Celsius", 12.0, new DateOnly(2026, 12, 13), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6188), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6188) },
                    { new Guid("fac83a78-8db7-4677-b8d4-176bea9881a3"), "Celsius", 13.0, new DateOnly(2026, 5, 3), new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6251), "Chilly", new DateTime(2024, 10, 6, 15, 21, 53, 539, DateTimeKind.Local).AddTicks(6251) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

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
                name: "CreatedDate",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "WeatherForecasts");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Summary", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("00a63995-a7e4-42b2-8408-a31f5fc8abbf"), "Freezing", new DateOnly(2026, 6, 20), "Fahrenheit", 13.0 },
                    { new Guid("0851bbdc-cf71-4009-9ba2-d4b1020e4aa8"), "Scorching", new DateOnly(2026, 7, 12), "Celsius", 22.0 },
                    { new Guid("19775645-82a7-4f10-917d-5a1e82c403f2"), "Hot", new DateOnly(2022, 1, 1), "Celsius", 1.0 },
                    { new Guid("28259e9d-fa7d-4915-baa7-85cba9ca31d2"), "Scorching", new DateOnly(2024, 7, 5), "Fahrenheit", 22.0 },
                    { new Guid("30eeeaee-12b4-4176-88a5-0045e32bcb6b"), "Unknown", new DateOnly(2022, 12, 24), "Fahrenheit", -1.0 },
                    { new Guid("4583e970-640c-409b-85eb-8bd5fb84ae4d"), "Freezing", new DateOnly(2023, 12, 27), "Celsius", -3.0 },
                    { new Guid("4c1ba407-415e-4894-a489-d1f9541ea658"), "Hot", new DateOnly(2022, 3, 7), "Fahrenheit", 22.0 },
                    { new Guid("4e844bd9-f72d-41ea-9939-713fe9198b20"), "Warm", new DateOnly(2023, 1, 9), "Fahrenheit", 32.0 },
                    { new Guid("5229527d-cea0-43a2-b14f-3e714bb6e0fb"), "Cool", new DateOnly(2022, 7, 12), "Fahrenheit", 22.0 },
                    { new Guid("831d8fda-64ce-414b-8ecc-1a90dc9f51ad"), "Warm", new DateOnly(2023, 4, 30), "Fahrenheit", 10.0 },
                    { new Guid("834debb2-fd24-4b4f-8c5a-11f0a9926976"), "Unknown", new DateOnly(2025, 7, 19), "Celsius", 9.0 },
                    { new Guid("9aec4c12-0917-43e7-ac68-30b76b473b54"), "Scorching", new DateOnly(2025, 4, 28), "Celsius", 15.0 },
                    { new Guid("9c7212f2-28b4-4ef2-bb15-16d60b9863eb"), "Unknown", new DateOnly(2027, 2, 7), "Fahrenheit", -1.0 },
                    { new Guid("b4315a8a-af9f-4966-ab77-c6bce7dbfc27"), "Unknown", new DateOnly(2027, 1, 26), "Fahrenheit", 9.0 },
                    { new Guid("b7ee5b3a-e2ef-4aa5-9fe1-e9bac4f46ab2"), "Chilly", new DateOnly(2025, 11, 27), "Fahrenheit", 29.0 },
                    { new Guid("bdea3223-7e74-42dc-9daa-90602e60e403"), "Warm", new DateOnly(2022, 3, 25), "Fahrenheit", 12.0 },
                    { new Guid("c46f97e2-8b6c-4c67-97d5-b9224c374cee"), "Mild", new DateOnly(2026, 2, 23), "Fahrenheit", 1.0 },
                    { new Guid("c7d15f40-1ac1-4b53-a0e5-7401aa095687"), "Unknown", new DateOnly(2023, 2, 17), "Fahrenheit", 25.0 },
                    { new Guid("cd25b402-d580-46e4-b3fa-f0ccd4d0c34c"), "Balmy", new DateOnly(2026, 4, 4), "Celsius", 2.0 },
                    { new Guid("e709a49a-2ca8-418f-bad4-3aa58f0041e1"), "Chilly", new DateOnly(2025, 11, 25), "Fahrenheit", 21.0 }
                });
        }
    }
}
