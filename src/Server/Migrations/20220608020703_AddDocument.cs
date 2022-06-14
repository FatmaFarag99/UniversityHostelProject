using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Applications_ApplicationId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ApplicationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Documents");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Documents",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Documents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAttachment_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "281ac179-ab9e-40d5-96e9-711a86f15754");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "1a369332-35bc-4082-bcca-777e8edae534");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c24b78fc-7ec4-4438-a71c-1d6813caf70b", "AQAAAAEAACcQAAAAEDRG66XY45zovITtYzoaLbqyPtQQ4+XxjbwRKGFIpXVOTwUqConC/7ZFTyjg1QPsAA==", "e20efe6b-226c-4949-9a9a-944142d97d22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f6dd8f8-e321-4ea3-bd00-f9aa37c3fbc3", "AQAAAAEAACcQAAAAELNxXQNjlvHPLF9JGDbqJB4N02ZVEjbSPd3rxKWHW0Ai1IyfQc/B5PXuvRN5Ust5jw==", "dfa1dfb7-32a8-4484-9afa-640081cf3c5d" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicationId",
                table: "Documents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAttachment_DocumentId",
                table: "DocumentAttachment",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Applications_ApplicationId",
                table: "Documents",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
