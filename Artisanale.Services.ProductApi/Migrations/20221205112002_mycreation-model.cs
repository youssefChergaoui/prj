using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artisanale.Services.ProductApi.Migrations
{
    public partial class mycreationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Libelle", "Price" },
                values: new object[] { 1, "", null, "", "chaiseBoisMassif", 15.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Libelle", "Price" },
                values: new object[] { 2, "", null, "", "ch", 15.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);
        }
    }
}
