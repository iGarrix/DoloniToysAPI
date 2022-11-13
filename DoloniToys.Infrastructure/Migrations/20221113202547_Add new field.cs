using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoloniToys.Infrastructure.Migrations
{
    public partial class Addnewfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Categories");
        }
    }
}
