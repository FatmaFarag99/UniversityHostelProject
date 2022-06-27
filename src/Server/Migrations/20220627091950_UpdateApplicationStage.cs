using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class UpdateApplicationStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResultSubmitted",
                table: "ApplicationStages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 7, 4, 11, 19, 50, 321, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "ApplicationStages",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "EndTime",
                value: new DateTime(2022, 7, 4, 11, 19, 50, 321, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "660eb227-6015-4339-a7db-8be59f9afc30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "60cf14a2-b8ca-43de-abf7-8d2b63497785");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c4c07ab-2697-4170-ac8a-e56c7ed61514", "AQAAAAEAACcQAAAAEEddoeW2t+QcQcw8qYR82Io6LLYK1b7oqA4CclfVKY7SK6sdHj/Jifl1bhxXeD7v5w==", "613ee74f-744f-45e1-a9b9-2f5840f97b53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acbe930d-b1f3-4705-8251-d88be674a850", "AQAAAAEAACcQAAAAEOqUQC+LhWIdX/7yLKP4b3p4S+nHuPOVmpLqRkQeGrVvyo+MPGDqxOhGX8B758YnvA==", "0ef0664b-a401-4f4c-bb04-16242f7c5701" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResultSubmitted",
                table: "ApplicationStages");

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "PhaseEndTime",
                value: new DateTime(2022, 6, 25, 21, 24, 40, 597, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "ApplicationStages",
                keyColumn: "Id",
                keyValue: new Guid("e9bb6388-d68d-4346-9981-3a0e8150498f"),
                column: "EndTime",
                value: new DateTime(2022, 6, 25, 21, 24, 40, 597, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "7856e4c4-1214-42cd-afcf-9bf7dd49f952");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "08def4a8-1efc-4351-94b4-06272ac5d562");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ad4d666-dfe7-4b55-836d-1560583ee485", "AQAAAAEAACcQAAAAEA07+/x+iFszZ8/Heuue8lw067fjQNnVUJX3xapTJVWaITmG9V9icRbBk+P13VLs3A==", "abd27573-62d3-4bf6-9a10-ffe70fe83af2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cfe1553-dc3b-446d-8d90-8bcb6a169e8f", "AQAAAAEAACcQAAAAENoNXozDBZGaVAj9pScnPUZB/PjzzgoAYC+lVdzkUgxiaR+Tw2/eL2+dPsxI1RP43g==", "c790f059-4979-4b54-826b-850f926a812f" });
        }
    }
}
