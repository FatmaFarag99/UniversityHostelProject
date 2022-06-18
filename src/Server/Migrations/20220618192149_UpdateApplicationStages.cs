using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class UpdateApplicationStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "ApplicationStages");

            migrationBuilder.AddColumn<int>(
                name: "StageStatus",
                table: "ApplicationStages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 6, 25, 21, 21, 48, 590, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "ApplicationStages",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "EndTime",
                value: new DateTime(2022, 6, 25, 21, 21, 48, 591, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "8c9522aa-c11d-4890-9809-08cc815df42a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "229dc10e-ff07-4aa8-8546-f9299d0c1992");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a27cded-0535-4249-8023-77215c9f94ab", "AQAAAAEAACcQAAAAEDJ/03HmswXcemX0gxTa72DnKRDDGGzBlRK6wGupMy6B9lvBiAOdo+Cdg1tS5UcWQA==", "d7fb81d8-0add-4528-b9c1-296a2e93ec2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efd72f9f-3d66-4006-b09a-2d144160c9d2", "AQAAAAEAACcQAAAAEImZxy4gfUVNCj+7H8ngU6TT/HiJC7PML6R1kJhNsrSwEEMISXi5C8NbASWLI8nOmQ==", "30375c31-53be-4669-84f7-3596b068e5f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StageStatus",
                table: "ApplicationStages");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "ApplicationStages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 6, 25, 21, 18, 16, 302, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "ApplicationStages",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                columns: new[] { "Enabled", "EndTime" },
                values: new object[] { true, new DateTime(2022, 6, 25, 21, 18, 16, 302, DateTimeKind.Local).AddTicks(2599) });

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
        }
    }
}
