using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class UpdateApplicationStages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationStageId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationStageId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
