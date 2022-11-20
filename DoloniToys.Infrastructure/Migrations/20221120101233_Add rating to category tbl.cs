using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoloniToys.Infrastructure.Migrations
{
    public partial class Addratingtocategorytbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Categories");
        }
    }
}
