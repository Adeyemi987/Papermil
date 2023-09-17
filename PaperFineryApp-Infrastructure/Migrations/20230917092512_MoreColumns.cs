using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaperFineryApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ef28c59-db74-4d14-a837-63997c746a65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "315b7d80-2040-41a0-890f-8bfa8b26dc67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c34fea1-9c63-47f3-a87d-0779d890f3d3");

            migrationBuilder.AlterColumn<int>(
                name: "ReferralPoints",
                table: "suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4198ef-c641-4a24-ba35-4f439b478c95", null, "Manufacturer", "MANUFACTURER" },
                    { "31a86f95-f44c-4f97-9421-70437600e177", null, "Admin", "ADMIN" },
                    { "53ec140d-c086-47c3-997a-c13e1fae7424", null, "Supplier", "SUPPLIER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4198ef-c641-4a24-ba35-4f439b478c95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a86f95-f44c-4f97-9421-70437600e177");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ec140d-c086-47c3-997a-c13e1fae7424");

            migrationBuilder.AlterColumn<string>(
                name: "ReferralPoints",
                table: "suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ef28c59-db74-4d14-a837-63997c746a65", null, "Admin", "ADMIN" },
                    { "315b7d80-2040-41a0-890f-8bfa8b26dc67", null, "Manufacturer", "MANUFACTURER" },
                    { "9c34fea1-9c63-47f3-a87d-0779d890f3d3", null, "Supplier", "SUPPLIER" }
                });
        }
    }
}
