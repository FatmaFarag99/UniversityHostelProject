using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class UpdateApplication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocument_ApplicationDocuments_ApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropTable(
                name: "ApplicationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationDocument_ApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropColumn(
                name: "DocumentsId",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ApplicationDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocument_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocument_Applications_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocument_Applications_ApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationDocument_ApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ApplicationDocument");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentsId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Document2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Document3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_ApplicationDocument_Document1Id",
                        column: x => x.Document1Id,
                        principalTable: "ApplicationDocument",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_ApplicationDocument_Document2Id",
                        column: x => x.Document2Id,
                        principalTable: "ApplicationDocument",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocument_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_ApplicationId",
                table: "ApplicationDocuments",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_Document1Id",
                table: "ApplicationDocuments",
                column: "Document1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_Document2Id",
                table: "ApplicationDocuments",
                column: "Document2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocument_ApplicationDocuments_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId",
                principalTable: "ApplicationDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
