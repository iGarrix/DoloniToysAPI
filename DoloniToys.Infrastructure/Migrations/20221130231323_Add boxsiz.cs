using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoloniToys.Infrastructure.Migrations
{
    public partial class Addboxsiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxSize",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxSize",
                table: "Products");
        }
    }
}
