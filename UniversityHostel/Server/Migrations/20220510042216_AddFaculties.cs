using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddFaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50877faa-1869-423c-a4c9-904658e828fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc878e3f-2618-4898-88db-2b8aabbfebe7");

            migrationBuilder.CreateTable(
                name: "Faculty",
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
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f235fa-bbb2-424a-8b91-3d7247f47b16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f97b9b9-297a-4541-b4bd-4c72e8101289");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50877faa-1869-423c-a4c9-904658e828fb", "981d495c-2623-4b46-bcfc-600edbd75e68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc878e3f-2618-4898-88db-2b8aabbfebe7", "eb0a22ae-f7a0-4f9e-b6ea-1bed5f986235", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0eff944-910d-4612-8957-937b31846160", "AQAAAAEAACcQAAAAEA2+bfRKybROagoooL+l794o3awXF8DIJto/FD3LbZ/myHO3vkSxsySvlORCu/q+5A==", "19172def-bcb0-4ba3-adb1-a3dd461c993f" });
        }
    }
}
