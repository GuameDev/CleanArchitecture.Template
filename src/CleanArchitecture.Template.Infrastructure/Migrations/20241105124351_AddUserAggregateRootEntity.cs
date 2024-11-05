using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAggregateRootEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureValue = table.Column<double>(type: "float", nullable: false),
                    TemperatureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "Description", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09012410-aaba-4cad-9da6-d26ef27d7146"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) },
                    { new Guid("73c375a3-dfa1-4a22-adfc-112c9b276108"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Can read data", "Read", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) },
                    { new Guid("879a1ba3-37f3-4316-86ed-1ec91eb0c24d"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Can modify data", "Write", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) },
                    { new Guid("c28901fa-f63b-45b8-8963-a3dfdbb58f1e"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) },
                    { new Guid("f46bb1e6-0b4d-4ba1-9871-ca9619ff1eaf"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Can manage users", "ManageUsers", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c0692c3c-6a31-4794-9dcf-08d7c732a158"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "User", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) },
                    { new Guid("f0244ef5-f519-474b-8a46-e643a2338705"), new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816), "Admin", new DateTime(2024, 11, 5, 12, 43, 50, 768, DateTimeKind.Utc).AddTicks(8816) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0978f7a1-82b8-47c3-9c30-278ef80073f6"), "Fahrenheit", 24.0, new DateOnly(2025, 8, 3), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8303), "Freezing", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8303) },
                    { new Guid("15d207e7-6541-452f-983b-6f862565e604"), "Celsius", 19.0, new DateOnly(2027, 7, 15), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8353), "Warm", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8353) },
                    { new Guid("25c006c3-ade9-42ac-914b-7ae2f7544b07"), "Fahrenheit", 0.0, new DateOnly(2027, 5, 24), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8370), "Chilly", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8370) },
                    { new Guid("270413df-409e-4999-9d40-add7d748181c"), "Celsius", 22.0, new DateOnly(2025, 7, 20), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8290), "Scorching", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8290) },
                    { new Guid("2adba033-dd8e-4662-9279-aacc29cb071d"), "Fahrenheit", -5.0, new DateOnly(2026, 10, 22), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8376), "Balmy", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8376) },
                    { new Guid("2cdf3933-097a-4707-8714-6403067c5d6b"), "Fahrenheit", 22.0, new DateOnly(2024, 5, 24), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8411), "Mild", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8411) },
                    { new Guid("35a91504-5bca-4b85-aeb1-b91a6f4bec77"), "Fahrenheit", 31.0, new DateOnly(2022, 4, 2), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8405), "Chilly", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8405) },
                    { new Guid("537c8ca3-61b0-4394-b42a-355e2d750e8f"), "Fahrenheit", -2.0, new DateOnly(2024, 5, 24), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8394), "Hot", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8394) },
                    { new Guid("5eba0bc4-bbd7-44cd-bc4a-34c31f633eb9"), "Fahrenheit", 13.0, new DateOnly(2025, 3, 23), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8387), "Hot", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8387) },
                    { new Guid("6dace619-cf85-4610-8c20-5c35e6b0a599"), "Fahrenheit", 34.0, new DateOnly(2025, 3, 2), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8416), "Mild", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8416) },
                    { new Guid("74d8aab9-9504-495d-87ee-d497a4dba8f6"), "Celsius", 29.0, new DateOnly(2024, 12, 23), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8390), "Scorching", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8390) },
                    { new Guid("7ed22a52-213f-4641-9dba-49d0faed4ea4"), "Fahrenheit", 6.0, new DateOnly(2026, 5, 29), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8323), "Balmy", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8323) },
                    { new Guid("81cb2ca3-5422-4431-b6bc-790da1860a56"), "Fahrenheit", 34.0, new DateOnly(2025, 12, 7), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8419), "Sweltering", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8419) },
                    { new Guid("84f1eeea-118a-44d4-9cb2-ec923558e47a"), "Celsius", 13.0, new DateOnly(2024, 8, 10), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8363), "Cool", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8363) },
                    { new Guid("96b77b38-511f-4888-912c-6b0f6426f3ac"), "Celsius", 16.0, new DateOnly(2023, 1, 20), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8401), "Chilly", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8401) },
                    { new Guid("9c515c4c-c6a0-4034-a03f-0b917bb31f20"), "Celsius", 3.0, new DateOnly(2024, 10, 19), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8398), "Warm", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8398) },
                    { new Guid("9f966203-4d85-4d84-b779-6f015751fdb3"), "Celsius", 20.0, new DateOnly(2024, 3, 30), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8367), "Mild", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8367) },
                    { new Guid("ec67d8a0-dfca-4492-a041-21a97ea471af"), "Celsius", 0.0, new DateOnly(2023, 8, 1), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8383), "Cool", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8383) },
                    { new Guid("f233b87c-38a6-4730-bc8f-5824ff96c553"), "Celsius", 23.0, new DateOnly(2022, 11, 1), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8349), "Warm", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8349) },
                    { new Guid("f6c5e0a9-090f-4c54-873d-aadcf00b9930"), "Fahrenheit", 6.0, new DateOnly(2023, 8, 25), new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8359), "Balmy", new DateTime(2024, 11, 5, 13, 43, 50, 768, DateTimeKind.Local).AddTicks(8359) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new Guid("73c375a3-dfa1-4a22-adfc-112c9b276108"), new Guid("f0244ef5-f519-474b-8a46-e643a2338705") },
                    { 2, new Guid("879a1ba3-37f3-4316-86ed-1ec91eb0c24d"), new Guid("f0244ef5-f519-474b-8a46-e643a2338705") },
                    { 3, new Guid("f46bb1e6-0b4d-4ba1-9871-ca9619ff1eaf"), new Guid("f0244ef5-f519-474b-8a46-e643a2338705") },
                    { 4, new Guid("09012410-aaba-4cad-9da6-d26ef27d7146"), new Guid("f0244ef5-f519-474b-8a46-e643a2338705") },
                    { 5, new Guid("c28901fa-f63b-45b8-8963-a3dfdbb58f1e"), new Guid("f0244ef5-f519-474b-8a46-e643a2338705") },
                    { 6, new Guid("73c375a3-dfa1-4a22-adfc-112c9b276108"), new Guid("c0692c3c-6a31-4794-9dcf-08d7c732a158") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
