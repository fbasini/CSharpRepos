using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandID", "Name" },
                values: new object[,]
                {
                    { 2, "Stella Artois" },
                    { 3, "Heineken" }
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerID", "BrandID", "Name" },
                values: new object[,]
                {
                    { 6, 2, "Golden" },
                    { 7, 3, "Ipa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beer",
                keyColumn: "BeerID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Beer",
                keyColumn: "BeerID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
