using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "dd8a86e1-36e2-481d-9471-d560ae2a5fc3", null, "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ab81119-e658-4293-a444-f91a5cb9a47e", 0, null, "5c95213f-628d-40ce-8a67-49b0b506dcc9", "selshahat@example.com", true, null, null, false, null, "selshahat@example.com", "selshahat@example.com", "AQAAAAIAAYagAAAAEMbrA7Gte2g4oZSaoUNnSXBgB1u13vBGFkLD5zIR+obIK3/E/vgjvRIf6HxL/8VpAQ==", null, false, "fbdfd7b9-aeea-4992-a144-ca5b952e9b7a", false, "selshahat@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "6ab81119-e658-4293-a444-f91a5cb9a47e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd8a86e1-36e2-481d-9471-d560ae2a5fc3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6ab81119-e658-4293-a444-f91a5cb9a47e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ab81119-e658-4293-a444-f91a5cb9a47e");
        }
    }
}
