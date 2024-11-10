using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationUsers : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { new Guid("197bfdbe-728d-49fd-8f51-90366c35afbd"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Can modify data", "Write", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) },
                    { new Guid("6e99d5d9-d4a0-441c-aae5-52f94ec857e5"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Can manage users", "ManageUsers", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) },
                    { new Guid("9590cc01-1056-4231-97e5-f41f28c5776e"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) },
                    { new Guid("ba40ca1e-fcdc-4a5d-8350-4ab5b12914b2"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Can read data", "Read", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) },
                    { new Guid("f9d77762-cfe8-431a-ad44-4b7aaddfd018"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "Admin", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) },
                    { new Guid("984ce415-1ea3-45fe-9df9-39c861db5f97"), new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074), "User", new DateTime(2024, 11, 10, 10, 47, 36, 473, DateTimeKind.Utc).AddTicks(8074) }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00de5867-d543-45bd-b0c5-05760d9ead0e"), "Fahrenheit", 18.0, new DateOnly(2023, 11, 12), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7486), "Bracing", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7486) },
                    { new Guid("03e1d04c-b96e-45b4-bdb8-4761fbb89edd"), "Fahrenheit", 14.0, new DateOnly(2024, 9, 26), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7608), "Unknown", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7608) },
                    { new Guid("1a54aa53-d7e1-4629-8fc0-76e39d05c159"), "Fahrenheit", 21.0, new DateOnly(2022, 6, 2), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7562), "Freezing", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7562) },
                    { new Guid("1cf3a799-acca-4402-b11d-5e960e26e173"), "Fahrenheit", 14.0, new DateOnly(2023, 4, 14), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7568), "Hot", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7568) },
                    { new Guid("2029f92e-81c4-46f7-a8a1-d4f11c5fc5a5"), "Fahrenheit", 23.0, new DateOnly(2024, 9, 1), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7551), "Mild", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7551) },
                    { new Guid("242e3a01-6d8e-4c7a-94b7-e7767163566e"), "Fahrenheit", 25.0, new DateOnly(2026, 6, 17), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7504), "Unknown", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7504) },
                    { new Guid("34e2dca4-e2d4-45ad-b19b-2fb3e4528690"), "Fahrenheit", 14.0, new DateOnly(2025, 7, 8), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7579), "Balmy", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7579) },
                    { new Guid("409b7aca-37d2-4e46-8efc-a3a7adaf45f7"), "Celsius", 15.0, new DateOnly(2025, 12, 9), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7492), "Unknown", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7492) },
                    { new Guid("615af106-905d-49f8-8956-115d140fdd73"), "Fahrenheit", 34.0, new DateOnly(2024, 4, 30), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7602), "Freezing", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7602) },
                    { new Guid("8423b65e-9aef-4c1e-84d4-0b87588582c6"), "Celsius", 30.0, new DateOnly(2027, 2, 6), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7587), "Scorching", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7587) },
                    { new Guid("8490e99d-9ab0-4adc-be13-4e30cd67e905"), "Celsius", 20.0, new DateOnly(2023, 12, 14), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7596), "Freezing", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7596) },
                    { new Guid("90e0b543-2da0-474c-a289-b29cfddf453b"), "Celsius", -5.0, new DateOnly(2023, 10, 7), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7536), "Mild", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7536) },
                    { new Guid("92e23374-a39d-42ad-b6b0-5be57a649afc"), "Celsius", 31.0, new DateOnly(2023, 3, 4), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7545), "Warm", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7545) },
                    { new Guid("9e7351cf-39a4-48ad-9539-ea89cf3e16dc"), "Celsius", 19.0, new DateOnly(2025, 6, 4), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7526), "Warm", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7526) },
                    { new Guid("a04c880f-e307-4db7-9039-4b17dab631d8"), "Fahrenheit", -3.0, new DateOnly(2024, 10, 28), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7498), "Hot", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7498) },
                    { new Guid("a20d3b85-3301-4eee-8541-6be816721489"), "Celsius", 6.0, new DateOnly(2027, 3, 28), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7556), "Balmy", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7556) },
                    { new Guid("b02426f2-2001-4e3a-82c0-eacdb72d9047"), "Fahrenheit", 8.0, new DateOnly(2022, 11, 10), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7573), "Unknown", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7573) },
                    { new Guid("b6854d34-4395-47ac-8168-364c13039d34"), "Celsius", 12.0, new DateOnly(2026, 7, 29), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7520), "Balmy", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7520) },
                    { new Guid("c72b81b9-c074-4698-ad65-395a8d9c223c"), "Celsius", 3.0, new DateOnly(2023, 3, 6), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7514), "Bracing", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7514) },
                    { new Guid("ce23e7ad-33b0-421d-b7e1-8cca54ae0bfa"), "Celsius", 6.0, new DateOnly(2027, 3, 4), new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7472), "Cool", new DateTime(2024, 11, 10, 11, 47, 36, 473, DateTimeKind.Local).AddTicks(7472) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new Guid("ba40ca1e-fcdc-4a5d-8350-4ab5b12914b2"), new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76") },
                    { 2, new Guid("197bfdbe-728d-49fd-8f51-90366c35afbd"), new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76") },
                    { 3, new Guid("6e99d5d9-d4a0-441c-aae5-52f94ec857e5"), new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76") },
                    { 4, new Guid("9590cc01-1056-4231-97e5-f41f28c5776e"), new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76") },
                    { 5, new Guid("f9d77762-cfe8-431a-ad44-4b7aaddfd018"), new Guid("1f3e7bae-39e0-46de-8c25-8c5d9454bf76") },
                    { 6, new Guid("ba40ca1e-fcdc-4a5d-8350-4ab5b12914b2"), new Guid("984ce415-1ea3-45fe-9df9-39c861db5f97") }
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
