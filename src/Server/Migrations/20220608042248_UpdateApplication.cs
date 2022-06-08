using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class UpdateApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Step",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "BasicInformationId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentsId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDocument_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Document2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Document3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PaymentId",
                table: "Applications",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocument_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocument_DocumentId",
                table: "ApplicationDocument",
                column: "DocumentId",
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
                name: "FK_Applications_Payments_PaymentId",
                table: "Applications",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocument_ApplicationDocuments_ApplicationId",
                table: "ApplicationDocument",
                column: "ApplicationId",
                principalTable: "ApplicationDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Payments_PaymentId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocument_ApplicationDocuments_ApplicationId",
                table: "ApplicationDocument");

            migrationBuilder.DropTable(
                name: "ApplicationDocuments");

            migrationBuilder.DropTable(
                name: "ApplicationDocument");

            migrationBuilder.DropIndex(
                name: "IX_Applications_PaymentId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BasicInformationId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DocumentsId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "Step",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "8273fb30-b7ae-4ea8-93cd-cc1e2ca2d13c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "21a49941-aad8-4149-ae0c-f58a79e7ae2a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07f8b86e-ea54-4204-9184-827dcbc23b5f", "AQAAAAEAACcQAAAAEI50tI4E5gW7WUfTueHZeCVah10vwygEn1NV4t4wDTTgdXT9gdskOfMXlU6pEHSmRg==", "1cba6722-9d66-4057-bc05-e5530c90effc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca9d379-6d8c-4547-a130-4f7e3ee806f0", "AQAAAAEAACcQAAAAECdVQhs5mFCgFRA4sBdRQcx+o9pEVTUs0uhnPuwziy2GC3rnp6PlthTDRELbBlUl4w==", "5c547157-cd02-4f6e-9f43-d7490e4d6c76" });
        }
    }
}
