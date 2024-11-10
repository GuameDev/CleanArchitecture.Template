using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationUserAndWeatherForecast : Migration
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    { new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) },
                    { new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Can read data", "Read", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) },
                    { new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Can modify data", "Write", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) },
                    { new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Can manage users", "ManageUsers", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) },
                    { new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "Admin", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) },
                    { new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), "User", new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("03cb802e-922e-4fb6-b4fc-9d1caa7052f8"), "Celsius", 9.0, new DateOnly(2022, 4, 15), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1094), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1094) },
                    { new Guid("0509733a-7d1e-4f7c-83a5-f3491014ed0b"), "Celsius", 2.0, new DateOnly(2023, 3, 4), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1202), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1202) },
                    { new Guid("0c912451-18a3-4cfd-89dc-ef62db54b5c1"), "Celsius", 10.0, new DateOnly(2026, 7, 5), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1135), "Unknown", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1135) },
                    { new Guid("10551331-8f13-49ae-8386-4e355cf4c512"), "Celsius", 19.0, new DateOnly(2023, 4, 7), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1194), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1194) },
                    { new Guid("255e6c53-f329-4758-b73c-ecfc0d81c620"), "Celsius", 24.0, new DateOnly(2025, 1, 3), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1174), "Chilly", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1174) },
                    { new Guid("32028c33-6c1e-4bd5-9edd-dbe144785601"), "Celsius", 27.0, new DateOnly(2024, 4, 17), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1162), "Unknown", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1162) },
                    { new Guid("320e2a87-f439-4834-bf9d-b555529b5a29"), "Fahrenheit", 0.0, new DateOnly(2022, 6, 8), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1078), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1078) },
                    { new Guid("338c71ff-91ec-4dd8-baa2-208f479505cb"), "Fahrenheit", 34.0, new DateOnly(2022, 2, 24), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1156), "Bracing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1156) },
                    { new Guid("5889e7f6-625c-47db-8638-19bc76f1e638"), "Celsius", 3.0, new DateOnly(2025, 8, 31), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1181), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1181) },
                    { new Guid("6939a6dc-bd06-4670-960c-6e32414fbbd1"), "Fahrenheit", 20.0, new DateOnly(2022, 7, 27), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1159), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1159) },
                    { new Guid("85c21b1b-8def-48f0-8a3f-3efaf3cf5671"), "Celsius", -4.0, new DateOnly(2025, 3, 15), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1191), "Warm", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1191) },
                    { new Guid("8cdc6177-9cf9-4bca-acde-c0af6ac70f89"), "Celsius", 7.0, new DateOnly(2024, 7, 6), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1187), "Sweltering", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1187) },
                    { new Guid("92c812e2-61e9-4962-b123-734237dc7e23"), "Celsius", 16.0, new DateOnly(2022, 6, 12), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1205), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1205) },
                    { new Guid("95934958-1bb2-436f-afcb-0ac2822aa6b9"), "Fahrenheit", 25.0, new DateOnly(2026, 4, 19), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1166), "Bracing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1166) },
                    { new Guid("a06116b9-9712-4af4-9a2c-ca4057a32c3c"), "Celsius", 26.0, new DateOnly(2023, 1, 12), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1128), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1128) },
                    { new Guid("b20b1228-e56c-42e7-b929-b6c9dcefab4c"), "Celsius", 1.0, new DateOnly(2022, 11, 24), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1171), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1171) },
                    { new Guid("d21a4710-2e64-4584-840f-9f5926cf4fd2"), "Celsius", 26.0, new DateOnly(2024, 5, 7), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1131), "Chilly", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1131) },
                    { new Guid("d50fa582-be68-43fd-9bfa-a35608acb28d"), "Fahrenheit", 30.0, new DateOnly(2024, 4, 12), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1178), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1178) },
                    { new Guid("dc9f12a2-020f-4fd3-a244-918003508078"), "Celsius", 12.0, new DateOnly(2026, 4, 4), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1208), "Balmy", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1208) },
                    { new Guid("f6a65463-8f04-4afc-b871-876fc7154ec0"), "Fahrenheit", 2.0, new DateOnly(2023, 11, 27), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1197), "Sweltering", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1197) }
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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

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
                name: "RefreshTokens");

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
