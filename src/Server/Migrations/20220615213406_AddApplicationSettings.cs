using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddApplicationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhaseEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRegistrationEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationSettings",
                columns: new[] { "Id", "DisplayOrder", "IsRegistrationEnabled", "PhaseEndTime" },
                values: new object[] { new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"), 0, true, new DateTime(2022, 6, 22, 23, 34, 6, 228, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "77e77a97-bc4f-4939-a514-2343e2a74f7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "747ed223-8b87-4e50-bd6e-07376372feef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b133f53d-6271-40aa-9da6-5277acf84c91", "AQAAAAEAACcQAAAAEOwGtdLEQY96A7cFWG3RnOx2RR7FtV1T44bii1pxvxscUAADyOsBLXHP4DTBliXrVQ==", "69c9e6f1-846f-4d25-9a55-8700ffd6a625" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83a3314a-51ca-4b86-b2e6-19989ba2f4e0", "AQAAAAEAACcQAAAAEG5hOvqRsCuNj7F1XOb7LuEm9b2eMPdv4KFUxzLeIo+RC/iNOGwFksk4qh8pg5AdIw==", "7810534c-a01c-4154-9d17-997c379b6535" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSettings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "181e3869-fef5-46dc-912f-bfe87b77c0db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "0cac89df-f445-418d-8561-192bd3f32e11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b403ffb3-3288-470d-b5a9-556962501a77", "AQAAAAEAACcQAAAAELj/wVilW5Cehs6tHJ5qwFOG+y274xhKJEXYv2rUHnRFNBHxpVHSRNkaTPM9RWdROg==", "ad4dd1c9-1b28-4ba3-98d6-1c1759c26576" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff3a2114-02fd-46af-9fc1-ff23c1ad3a83", "AQAAAAEAACcQAAAAEO+pL2KfcsnwwlGBErjdCHN75GNVEHtPc6z71TdrHR+vYFDtiHYvX/0CAQDrPkJLRQ==", "c64055a7-2893-48c1-b46e-5d7f8d6a2e26" });
        }
    }
}
