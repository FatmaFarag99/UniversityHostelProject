using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHostel.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
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
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
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
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residences",
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
                    table.PrimaryKey("PK_Residences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSpecialNeeds = table.Column<bool>(type: "bit", nullable: false),
                    IsFamilyOutside = table.Column<bool>(type: "bit", nullable: false),
                    Degree = table.Column<double>(type: "float", nullable: false),
                    PreviousGPA = table.Column<double>(type: "float", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    HousingType = table.Column<int>(type: "int", nullable: false),
                    ResidenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSecondLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicInformations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicInformations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicInformations_Residences_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da80425e-f97f-469b-98ef-bd481b034777", "bf9a666f-bef4-4641-a866-7e849b71ceac", "Admin", "ADMIN" },
                    { "e9bb6388-d68d-4346-9981-3a0e8150498f", "277752e2-da7f-4a87-976f-989c7f79442a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7", 0, "67ef2513-f925-4819-bd5e-39821c27fb59", "AppUser", "Admin@hostel.com", true, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBXYeQFMAk0pRhk/jpUPo2/B6x4pgWUECz3pMh/mUZZMlVBl2zuQMLXRhDFB0J6yBA==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c50d34e7-f618-4bcd-94b0-9d9df404ee92", false, "Admin" },
                    { "cca1c549-094b-4c45-a9c1-9960068e7f51", 0, "97ddb309-2298-4a38-8391-a6a9059ce6bc", "AppUser", "user@hostel.com", true, null, false, null, null, "USER", "AQAAAAEAACcQAAAAEHiy9+G6X0ZHjE3TXqAF8LgbINCtwsvEQsb/HLF4w2pfExn3saDLDx+n2P73knFxRA==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2275a7f1-52ff-4c9f-a277-e5332c5bd34c", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "da80425e-f97f-469b-98ef-bd481b034777", "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9bb6388-d68d-4346-9981-3a0e8150498f", "cca1c549-094b-4c45-a9c1-9960068e7f51" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformations_ApplicationId",
                table: "BasicInformations",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformations_FacultyId",
                table: "BasicInformations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformations_ResidenceId",
                table: "BasicInformations",
                column: "ResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAttachment_DocumentId",
                table: "DocumentAttachment",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicationId",
                table: "Documents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ApplicationId",
                table: "Payments",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BasicInformations");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "DocumentAttachment");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Residences");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
