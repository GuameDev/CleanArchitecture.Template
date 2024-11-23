using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "Description", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Can view the dashboard", "ViewDashboard", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Can read data", "Read", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Can modify data", "Write", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Can manage users", "ManageUsers", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Can manage roles and permissions", "ManageRoles", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Admin", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "User", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) }
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
        }
    }
}
