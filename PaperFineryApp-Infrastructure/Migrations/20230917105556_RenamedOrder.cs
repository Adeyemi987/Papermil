using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaperFineryApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PaperTypeAndKg",
                table: "Orders",
                newName: "productImageUrl");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Orders",
                newName: "SupplierLocation");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Orders",
                newName: "PapertypeDesc");

            migrationBuilder.AlterColumn<int>(
                name: "TotalWeightInKg",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryModesDesc",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatusDesc",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Papertype",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalWeightInkgDesc",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeliveryModesDesc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusDesc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Papertype",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalWeightInkgDesc",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "productImageUrl",
                table: "Orders",
                newName: "PaperTypeAndKg");

            migrationBuilder.RenameColumn(
                name: "SupplierLocation",
                table: "Orders",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "PapertypeDesc",
                table: "Orders",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<double>(
                name: "TotalWeightInKg",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
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
    }
}
