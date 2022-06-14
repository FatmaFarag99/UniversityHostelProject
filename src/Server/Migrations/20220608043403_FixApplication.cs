using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class FixApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentsId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BasicInformationId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentsId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BasicInformationId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "1b876fb8-46c5-473d-a4e7-0a1c9e31107a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "a5f44834-6d09-4913-9e80-333123b501cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "213070e5-a799-4726-96da-f1d170bdff91", "AQAAAAEAACcQAAAAEH3Qhny0yU6CbcGi5OHgo1ssGfDLh1czdmxAd4/4TgnXhnlcASd/WUYkXJ2HQUAioA==", "58240daa-f5d9-4e92-84bd-3356a414bc46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22f19c33-38e5-447f-875b-579254a54572", "AQAAAAEAACcQAAAAEBfgYz2nzM4EHmjMmVXaNOSkgd+1yf2KR3UeC4Uk57v9jZn+1wcQrqDI6cRzndH9uw==", "dfa41537-b4fb-472f-b650-d3f73e750db0" });
        }
    }
}
