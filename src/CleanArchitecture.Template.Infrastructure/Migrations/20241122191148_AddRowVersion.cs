using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("03cb802e-922e-4fb6-b4fc-9d1caa7052f8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0509733a-7d1e-4f7c-83a5-f3491014ed0b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0c912451-18a3-4cfd-89dc-ef62db54b5c1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("10551331-8f13-49ae-8386-4e355cf4c512"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("255e6c53-f329-4758-b73c-ecfc0d81c620"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("32028c33-6c1e-4bd5-9edd-dbe144785601"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("320e2a87-f439-4834-bf9d-b555529b5a29"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("338c71ff-91ec-4dd8-baa2-208f479505cb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5889e7f6-625c-47db-8638-19bc76f1e638"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6939a6dc-bd06-4670-960c-6e32414fbbd1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("85c21b1b-8def-48f0-8a3f-3efaf3cf5671"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8cdc6177-9cf9-4bca-acde-c0af6ac70f89"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("92c812e2-61e9-4962-b123-734237dc7e23"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("95934958-1bb2-436f-afcb-0ac2822aa6b9"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a06116b9-9712-4af4-9a2c-ca4057a32c3c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b20b1228-e56c-42e7-b929-b6c9dcefab4c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d21a4710-2e64-4584-840f-9f5926cf4fd2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d50fa582-be68-43fd-9bfa-a35608acb28d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("dc9f12a2-020f-4fd3-a244-918003508078"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f6a65463-8f04-4afc-b871-876fc7154ec0"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "WeatherForecasts",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Users",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Roles",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RefreshTokens",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Permissions",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 11, 22, 19, 11, 47, 686, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "TemperatureType", "TemperatureValue", "Date", "CreatedDate", "RowVersion", "Summary", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("081bba58-52aa-4833-968c-b6b5d6fa418a"), "Fahrenheit", 6.0, new DateOnly(2024, 1, 11), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5055), new byte[] { 0, 0, 0, 0, 0 }, "Unknown", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5055) },
                    { new Guid("0aafd114-0bbd-40cd-94f9-499088828dc6"), "Fahrenheit", 28.0, new DateOnly(2027, 2, 18), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4922), new byte[] { 0, 0, 0, 0, 0 }, "Warm", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4922) },
                    { new Guid("28b72b8e-7997-429e-838e-fe30497a1c41"), "Celsius", 23.0, new DateOnly(2023, 11, 24), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5045), new byte[] { 0, 0, 0, 0, 0 }, "Hot", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5045) },
                    { new Guid("3b88b48f-efce-49c3-85ea-7d40cdcefec1"), "Celsius", 14.0, new DateOnly(2025, 1, 31), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5000), new byte[] { 0, 0, 0, 0, 0 }, "Balmy", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5000) },
                    { new Guid("526ce316-9b97-4dce-9897-92d8edb529be"), "Fahrenheit", -3.0, new DateOnly(2022, 11, 15), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5033), new byte[] { 0, 0, 0, 0, 0 }, "Hot", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5033) },
                    { new Guid("5426bd61-af0c-4331-a6b1-804ed2dc50c7"), "Celsius", 31.0, new DateOnly(2026, 4, 30), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5050), new byte[] { 0, 0, 0, 0, 0 }, "Chilly", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5050) },
                    { new Guid("6414dcae-3530-4166-80d6-7920d889d557"), "Celsius", 24.0, new DateOnly(2024, 1, 16), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4917), new byte[] { 0, 0, 0, 0, 0 }, "Balmy", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4917) },
                    { new Guid("6ad8409c-4e18-4c7e-baca-aeb2f6e73e3f"), "Celsius", -4.0, new DateOnly(2023, 12, 18), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4912), new byte[] { 0, 0, 0, 0, 0 }, "Freezing", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4912) },
                    { new Guid("7feed608-3f4c-4aab-a9dc-5127809eb059"), "Celsius", 25.0, new DateOnly(2022, 5, 30), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5011), new byte[] { 0, 0, 0, 0, 0 }, "Hot", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5011) },
                    { new Guid("8618245a-56c4-4440-80f1-a322aad80cbc"), "Fahrenheit", 8.0, new DateOnly(2025, 5, 22), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5077), new byte[] { 0, 0, 0, 0, 0 }, "Balmy", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5077) },
                    { new Guid("9f9f6872-54aa-4d0f-b407-35735556160e"), "Celsius", 6.0, new DateOnly(2023, 6, 11), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5023), new byte[] { 0, 0, 0, 0, 0 }, "Scorching", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5023) },
                    { new Guid("b39605c8-ca03-44c3-8e91-c9b20391ff35"), "Fahrenheit", 0.0, new DateOnly(2023, 9, 15), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5015), new byte[] { 0, 0, 0, 0, 0 }, "Cool", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5015) },
                    { new Guid("ba3ce6e8-214c-46e2-8d05-7a079ca57a23"), "Celsius", 22.0, new DateOnly(2022, 7, 12), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5072), new byte[] { 0, 0, 0, 0, 0 }, "Mild", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5072) },
                    { new Guid("c3e9b858-fb29-4f4a-89f4-ba94d010a02a"), "Fahrenheit", 5.0, new DateOnly(2026, 7, 30), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5060), new byte[] { 0, 0, 0, 0, 0 }, "Freezing", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5060) },
                    { new Guid("d969799c-0ce6-44d4-9899-277ea9b6a160"), "Celsius", 19.0, new DateOnly(2024, 11, 24), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4889), new byte[] { 0, 0, 0, 0, 0 }, "Sweltering", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4889) },
                    { new Guid("df970055-9225-487b-b39a-a71640282a30"), "Celsius", 26.0, new DateOnly(2026, 12, 20), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4907), new byte[] { 0, 0, 0, 0, 0 }, "Hot", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(4907) },
                    { new Guid("e0730570-46e6-42c2-bf78-e142e705bb94"), "Fahrenheit", 34.0, new DateOnly(2023, 5, 22), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5068), new byte[] { 0, 0, 0, 0, 0 }, "Balmy", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5068) },
                    { new Guid("e5a15d0b-10ef-43c8-9802-d8320df71529"), "Fahrenheit", 31.0, new DateOnly(2024, 12, 11), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5038), new byte[] { 0, 0, 0, 0, 0 }, "Balmy", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5038) },
                    { new Guid("f9da87a0-57ff-46c8-ae2f-29302b8b3775"), "Celsius", 33.0, new DateOnly(2027, 3, 13), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5006), new byte[] { 0, 0, 0, 0, 0 }, "Scorching", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5006) },
                    { new Guid("ffb558ee-0624-4f1d-8b7f-7d6bb946b586"), "Celsius", -5.0, new DateOnly(2025, 8, 23), new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5028), new byte[] { 0, 0, 0, 0, 0 }, "Unknown", new DateTime(2024, 11, 22, 20, 11, 47, 686, DateTimeKind.Local).AddTicks(5028) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("081bba58-52aa-4833-968c-b6b5d6fa418a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0aafd114-0bbd-40cd-94f9-499088828dc6"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("28b72b8e-7997-429e-838e-fe30497a1c41"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3b88b48f-efce-49c3-85ea-7d40cdcefec1"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("526ce316-9b97-4dce-9897-92d8edb529be"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("5426bd61-af0c-4331-a6b1-804ed2dc50c7"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6414dcae-3530-4166-80d6-7920d889d557"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6ad8409c-4e18-4c7e-baca-aeb2f6e73e3f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7feed608-3f4c-4aab-a9dc-5127809eb059"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8618245a-56c4-4440-80f1-a322aad80cbc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9f9f6872-54aa-4d0f-b407-35735556160e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b39605c8-ca03-44c3-8e91-c9b20391ff35"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ba3ce6e8-214c-46e2-8d05-7a079ca57a23"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c3e9b858-fb29-4f4a-89f4-ba94d010a02a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d969799c-0ce6-44d4-9899-277ea9b6a160"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("df970055-9225-487b-b39a-a71640282a30"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e0730570-46e6-42c2-bf78-e142e705bb94"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e5a15d0b-10ef-43c8-9802-d8320df71529"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f9da87a0-57ff-46c8-ae2f-29302b8b3775"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ffb558ee-0624-4f1d-8b7f-7d6bb946b586"));

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a8b61357-15f2-48a1-9114-2d2d885de8c1"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c3c11234-56b8-4e89-91f4-21e1e69e76fa"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f6027a94-318d-4d13-b78f-9277cd3f7086"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759), new DateTime(2024, 11, 10, 14, 45, 45, 95, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "CreatedDate", "Summary", "UpdatedDate", "Date", "TemperatureType", "TemperatureValue" },
                values: new object[,]
                {
                    { new Guid("03cb802e-922e-4fb6-b4fc-9d1caa7052f8"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1094), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1094), new DateOnly(2022, 4, 15), "Celsius", 9.0 },
                    { new Guid("0509733a-7d1e-4f7c-83a5-f3491014ed0b"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1202), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1202), new DateOnly(2023, 3, 4), "Celsius", 2.0 },
                    { new Guid("0c912451-18a3-4cfd-89dc-ef62db54b5c1"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1135), "Unknown", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1135), new DateOnly(2026, 7, 5), "Celsius", 10.0 },
                    { new Guid("10551331-8f13-49ae-8386-4e355cf4c512"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1194), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1194), new DateOnly(2023, 4, 7), "Celsius", 19.0 },
                    { new Guid("255e6c53-f329-4758-b73c-ecfc0d81c620"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1174), "Chilly", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1174), new DateOnly(2025, 1, 3), "Celsius", 24.0 },
                    { new Guid("32028c33-6c1e-4bd5-9edd-dbe144785601"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1162), "Unknown", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1162), new DateOnly(2024, 4, 17), "Celsius", 27.0 },
                    { new Guid("320e2a87-f439-4834-bf9d-b555529b5a29"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1078), "Cool", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1078), new DateOnly(2022, 6, 8), "Fahrenheit", 0.0 },
                    { new Guid("338c71ff-91ec-4dd8-baa2-208f479505cb"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1156), "Bracing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1156), new DateOnly(2022, 2, 24), "Fahrenheit", 34.0 },
                    { new Guid("5889e7f6-625c-47db-8638-19bc76f1e638"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1181), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1181), new DateOnly(2025, 8, 31), "Celsius", 3.0 },
                    { new Guid("6939a6dc-bd06-4670-960c-6e32414fbbd1"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1159), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1159), new DateOnly(2022, 7, 27), "Fahrenheit", 20.0 },
                    { new Guid("85c21b1b-8def-48f0-8a3f-3efaf3cf5671"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1191), "Warm", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1191), new DateOnly(2025, 3, 15), "Celsius", -4.0 },
                    { new Guid("8cdc6177-9cf9-4bca-acde-c0af6ac70f89"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1187), "Sweltering", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1187), new DateOnly(2024, 7, 6), "Celsius", 7.0 },
                    { new Guid("92c812e2-61e9-4962-b123-734237dc7e23"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1205), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1205), new DateOnly(2022, 6, 12), "Celsius", 16.0 },
                    { new Guid("95934958-1bb2-436f-afcb-0ac2822aa6b9"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1166), "Bracing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1166), new DateOnly(2026, 4, 19), "Fahrenheit", 25.0 },
                    { new Guid("a06116b9-9712-4af4-9a2c-ca4057a32c3c"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1128), "Freezing", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1128), new DateOnly(2023, 1, 12), "Celsius", 26.0 },
                    { new Guid("b20b1228-e56c-42e7-b929-b6c9dcefab4c"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1171), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1171), new DateOnly(2022, 11, 24), "Celsius", 1.0 },
                    { new Guid("d21a4710-2e64-4584-840f-9f5926cf4fd2"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1131), "Chilly", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1131), new DateOnly(2024, 5, 7), "Celsius", 26.0 },
                    { new Guid("d50fa582-be68-43fd-9bfa-a35608acb28d"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1178), "Scorching", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1178), new DateOnly(2024, 4, 12), "Fahrenheit", 30.0 },
                    { new Guid("dc9f12a2-020f-4fd3-a244-918003508078"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1208), "Balmy", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1208), new DateOnly(2026, 4, 4), "Celsius", 12.0 },
                    { new Guid("f6a65463-8f04-4afc-b871-876fc7154ec0"), new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1197), "Sweltering", new DateTime(2024, 11, 10, 15, 45, 45, 95, DateTimeKind.Local).AddTicks(1197), new DateOnly(2023, 11, 27), "Fahrenheit", 2.0 }
                });
        }
    }
}
