using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoloniToys.Infrastructure.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Article",
                table: "Products",
                column: "Article",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Article",
                table: "Products");
        }
    }
}
