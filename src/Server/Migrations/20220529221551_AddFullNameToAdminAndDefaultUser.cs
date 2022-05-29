using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class AddFullNameToAdminAndDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d50bf28-ab1a-47d4-8fea-8433b5d9c0c0", "Adminstrator", "AQAAAAEAACcQAAAAEAiZF3mtHHuZS9gIqMgAspMH2roFZLEkh5bS95wJb6L3JKe678aZPjE5XILpywWJaA==", "a0864d92-bc75-4a0a-b4e6-fd69824cea3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c10ca2f-e95c-40a7-8d0d-9bf4a491f87f", "Default User", "AQAAAAEAACcQAAAAEJBERUXgA3zyUpemXVo57ql2+IOCs+m3qwT2fiHGQn+D4os6gTzT0kjFLZ5iaLY6yQ==", "d488a363-c898-480f-a6da-d12d191f52f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da80425e-f97f-469b-98ef-bd481b034777",
                column: "ConcurrencyStamp",
                value: "bf9a666f-bef4-4641-a866-7e849b71ceac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9bb6388-d68d-4346-9981-3a0e8150498f",
                column: "ConcurrencyStamp",
                value: "277752e2-da7f-4a87-976f-989c7f79442a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67ef2513-f925-4819-bd5e-39821c27fb59", null, "AQAAAAEAACcQAAAAEBXYeQFMAk0pRhk/jpUPo2/B6x4pgWUECz3pMh/mUZZMlVBl2zuQMLXRhDFB0J6yBA==", "c50d34e7-f618-4bcd-94b0-9d9df404ee92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1c549-094b-4c45-a9c1-9960068e7f51",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97ddb309-2298-4a38-8391-a6a9059ce6bc", null, "AQAAAAEAACcQAAAAEHiy9+G6X0ZHjE3TXqAF8LgbINCtwsvEQsb/HLF4w2pfExn3saDLDx+n2P73knFxRA==", "2275a7f1-52ff-4c9f-a277-e5332c5bd34c" });
        }
    }
}
