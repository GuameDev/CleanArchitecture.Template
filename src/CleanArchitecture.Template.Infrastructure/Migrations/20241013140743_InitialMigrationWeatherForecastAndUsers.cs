using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationWeatherForecastAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
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
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can read data", "Read", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("4c30daa1-e676-4adb-80d4-39b89fe66b38"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("5897a698-c9de-4539-891a-fafdb7cfb6b2"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("798b3227-f830-4ad7-bae3-a48412f73024"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can manage users", "ManageUsers", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("dec0a8b0-488c-45e9-b947-610159067013"), new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090), "Can modify data", "Write", new DateTime(2024, 10, 13, 14, 7, 42, 674, DateTimeKind.Utc).AddTicks(5090) }
                });

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
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("10a5461d-5f6e-421f-981b-5baee57e7b81"), "Celsius", 31.0, new DateOnly(2022, 12, 15), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4682), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4682) },
                    { new Guid("22d9980c-eced-4e6f-b640-defc605b0083"), "Fahrenheit", -5.0, new DateOnly(2024, 6, 13), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4661), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4661) },
                    { new Guid("32084b7a-b93a-4c23-8fd4-57377de78e5b"), "Celsius", 15.0, new DateOnly(2022, 11, 26), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4595), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4595) },
                    { new Guid("34a3834b-05f6-4b17-91da-ea35eb362241"), "Fahrenheit", 28.0, new DateOnly(2025, 5, 13), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4655), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4655) },
                    { new Guid("374bd98b-d621-4d3c-b7d6-8e8d80a29cb3"), "Fahrenheit", 16.0, new DateOnly(2026, 10, 13), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4678), "Hot", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4678) },
                    { new Guid("46ff8b53-84a6-4ca5-b111-aaf70f4be516"), "Celsius", 27.0, new DateOnly(2024, 5, 29), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4642), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4642) },
                    { new Guid("6325998e-c6e0-45ef-9990-73aa66952160"), "Fahrenheit", -1.0, new DateOnly(2026, 3, 13), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4636), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4636) },
                    { new Guid("6a92bfca-6597-4e58-864d-f842dc2813f4"), "Fahrenheit", 13.0, new DateOnly(2027, 1, 17), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4618), "Scorching", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4618) },
                    { new Guid("7e71704f-bbee-4fd3-8ba3-bb2308b820cc"), "Fahrenheit", 23.0, new DateOnly(2026, 10, 28), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4614), "Sweltering", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4614) },
                    { new Guid("81a72c6f-f2ac-4920-a797-89b36203d88c"), "Fahrenheit", 18.0, new DateOnly(2026, 1, 27), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4652), "Bracing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4652) },
                    { new Guid("8519ad1d-a316-48c4-8faa-3c912e0dd6e6"), "Celsius", 8.0, new DateOnly(2023, 10, 14), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4685), "Balmy", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4685) },
                    { new Guid("8b9b3bfe-de05-4a25-a9df-705954a23bee"), "Fahrenheit", 17.0, new DateOnly(2023, 1, 29), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4629), "Warm", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4629) },
                    { new Guid("8c44ad18-bf42-4e6a-87e5-897c4fdd0c83"), "Fahrenheit", -1.0, new DateOnly(2024, 8, 8), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4673), "Scorching", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4673) },
                    { new Guid("9b3c23ee-0433-4774-8cdd-21c5fc0a081f"), "Celsius", 28.0, new DateOnly(2022, 12, 26), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4621), "Unknown", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4621) },
                    { new Guid("a98a1705-c525-450c-8f58-7065f4863598"), "Celsius", -1.0, new DateOnly(2023, 11, 20), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4609), "Sweltering", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4609) },
                    { new Guid("adef71eb-e132-4a5f-ac46-8950a9ace635"), "Celsius", 24.0, new DateOnly(2026, 6, 23), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4668), "Freezing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4668) },
                    { new Guid("b137656c-0c66-4ec5-8ffc-66e0cce9ae8f"), "Celsius", 19.0, new DateOnly(2026, 5, 14), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4664), "Balmy", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4664) },
                    { new Guid("c6304d0a-6708-4e2d-8841-ee243a748694"), "Celsius", -4.0, new DateOnly(2023, 5, 9), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4648), "Cool", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4648) },
                    { new Guid("e38eb104-9460-4fe1-97b1-e7b4d64d6ae8"), "Celsius", -2.0, new DateOnly(2025, 6, 28), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4658), "Freezing", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4658) },
                    { new Guid("ea3be4a3-426c-4f96-ba39-80b05669426b"), "Fahrenheit", 31.0, new DateOnly(2024, 5, 30), new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4632), "Hot", new DateTime(2024, 10, 13, 16, 7, 42, 674, DateTimeKind.Local).AddTicks(4632) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") },
                    { 2, new Guid("dec0a8b0-488c-45e9-b947-610159067013"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") },
                    { 3, new Guid("798b3227-f830-4ad7-bae3-a48412f73024"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") },
                    { 4, new Guid("5897a698-c9de-4539-891a-fafdb7cfb6b2"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") },
                    { 5, new Guid("4c30daa1-e676-4adb-80d4-39b89fe66b38"), new Guid("9b6afdaa-cf3f-4316-b647-e05d9ae34990") },
                    { 6, new Guid("4b5b753f-0eb8-4ba5-befd-3625df946efb"), new Guid("72df50b1-b6c6-4a04-b2f5-80938ff0bbcd") }
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
