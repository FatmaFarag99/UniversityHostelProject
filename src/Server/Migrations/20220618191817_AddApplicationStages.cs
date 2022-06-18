using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddApplicationStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationStageId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 6, 25, 21, 18, 16, 302, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.InsertData(
                table: "ApplicationStages",
                columns: new[] { "Id", "DisplayOrder", "Enabled", "EndTime" },
                values: new object[] { new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"), 0, true, new DateTime(2022, 6, 25, 21, 18, 16, 302, DateTimeKind.Local).AddTicks(2599) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "b7d1c672-093e-4fd6-b4e8-a00c9016d8b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "18a0fd54-2ecc-4b6c-8c59-53f7f2b1feaa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "187a0298-d9bf-44d5-ac41-4b387b92d244", "AQAAAAEAACcQAAAAENDPTy9fdOjrZHb5IjBDlxIhfAGK1Q1mguBFVXw8nJsrP5cixt/2To1enIWyUzh1ZA==", "cae17a17-8abd-4089-8dbd-915949e35d82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad5628a-425c-4d97-acac-b75db9d2b07a", "AQAAAAEAACcQAAAAEJkxZY4cuuC7JumXiVexcgw+PG9c8+Y82cuGsA+UDXZYkibMS3NJXjlnc5uo1/iXCg==", "c138b0c7-634b-4fe8-a23a-8fdd52b1c95c" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStageId",
                table: "Applications",
                column: "ApplicationStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStages_ApplicationStageId",
                table: "Applications",
                column: "ApplicationStageId",
                principalTable: "ApplicationStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStages_ApplicationStageId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationStages");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationStageId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationStageId",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 6, 22, 23, 34, 6, 228, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "c264cefc-346d-46c2-9e7d-31f3d17d61f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "92dd7c8f-a2c6-4eb1-8383-f2042e66bd30");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "761293b7-287c-4f75-9b01-6e0a09dd8a1a", "AQAAAAEAACcQAAAAEAPMV0sNqibpstC8kRUkakm61wAv7ncNJLCfqtLBcd8HFAGt5RFFIWEjrJSEuA2p+w==", "eebc9f2c-0303-405e-ba94-fa49eb5cc22c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "845acc3b-3bd2-4b8d-aa40-4a8963e51ca3", "AQAAAAEAACcQAAAAEDCoXp67BAVu+r7Gi7TbRBgD6ucxYRGTLD6rZ6VQBBdqNxdM/Ndmw6KT1bWO3j/s4w==", "a47afbb0-405d-43c4-aa3d-f2c09cc64f68" });
        }
    }
}
