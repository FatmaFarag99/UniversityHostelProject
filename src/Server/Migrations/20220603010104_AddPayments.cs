using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Applications_ApplicationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ApplicationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_Payments_TransactionId",
                table: "Payments",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "abfd5b73-f18d-49d6-bc35-203437c76f1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "9a5c2328-3534-4343-8d48-3ab8605a51a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d50bf28-ab1a-47d4-8fea-8433b5d9c0c0", "AQAAAAEAACcQAAAAEAiZF3mtHHuZS9gIqMgAspMH2roFZLEkh5bS95wJb6L3JKe678aZPjE5XILpywWJaA==", "a0864d92-bc75-4a0a-b4e6-fd69824cea3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c10ca2f-e95c-40a7-8d0d-9bf4a491f87f", "AQAAAAEAACcQAAAAEJBERUXgA3zyUpemXVo57ql2+IOCs+m3qwT2fiHGQn+D4os6gTzT0kjFLZ5iaLY6yQ==", "d488a363-c898-480f-a6da-d12d191f52f2" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ApplicationId",
                table: "Payments",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Applications_ApplicationId",
                table: "Payments",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
