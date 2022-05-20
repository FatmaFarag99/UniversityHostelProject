using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddResidences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f235fa-bbb2-424a-8b91-3d7247f47b16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f97b9b9-297a-4541-b4bd-4c72e8101289");

            migrationBuilder.CreateTable(
                name: "Residence",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSecondLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be15bd1e-4254-4ba0-bf84-460c9b985ff5", "80a3dec0-1a45-4499-abc1-a1dd57c8783d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e997d1be-999e-4206-b756-11ccb9de2349", "b94b9dd3-04a1-46ae-8b11-3b9e7293b378", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b17ae1b7-f51a-4afe-957b-24855055e5ba", "AQAAAAEAACcQAAAAEJ+5tSphRNQ9b09iIcHb2AUjhmjHxBVBgNN//w+v1ULXqkNneEUlYyHpnKjYBITY9A==", "5e10096c-3572-4fe4-8578-e7dddb1802aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be15bd1e-4254-4ba0-bf84-460c9b985ff5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e997d1be-999e-4206-b756-11ccb9de2349");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00f235fa-bbb2-424a-8b91-3d7247f47b16", "7d118949-29db-4bc8-be72-2b76b21a79e2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f97b9b9-297a-4541-b4bd-4c72e8101289", "6e53860e-3594-4c41-9b41-b6098df0cc92", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe410d16-5c4f-40c5-85eb-bde72b1621cd", "AQAAAAEAACcQAAAAEAp2dkOw0oJOJ76Xacx2oKY04h0MXDqK9PGictLDWhQhBYF/QT9huA9gAuBcGBJMjg==", "1bc14cb0-fe37-448d-a35f-e69bb9d841cb" });
        }
    }
}
