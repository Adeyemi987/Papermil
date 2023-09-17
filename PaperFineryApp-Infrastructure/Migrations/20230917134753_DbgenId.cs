using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaperFineryApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbgenId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bd003c3-9b90-47f4-9232-dfa1ce86d930");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0822582-1e1a-4dcc-a6c0-53f3a160a7e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e4787f-8351-4c0d-8338-742dbf44da4d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a0bf7fe-21a5-40b5-943b-85682172472b", null, "Admin", "ADMIN" },
                    { "28bc92b6-77bf-44e6-8e8e-d74b8fec71c1", null, "Manufacturer", "MANUFACTURER" },
                    { "298d6e33-91c6-4992-ab92-5ca27589cd28", null, "Supplier", "SUPPLIER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a0bf7fe-21a5-40b5-943b-85682172472b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28bc92b6-77bf-44e6-8e8e-d74b8fec71c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298d6e33-91c6-4992-ab92-5ca27589cd28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6bd003c3-9b90-47f4-9232-dfa1ce86d930", null, "Supplier", "SUPPLIER" },
                    { "a0822582-1e1a-4dcc-a6c0-53f3a160a7e2", null, "Manufacturer", "MANUFACTURER" },
                    { "f2e4787f-8351-4c0d-8338-742dbf44da4d", null, "Admin", "ADMIN" }
                });
        }
    }
}
