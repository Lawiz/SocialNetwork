using Microsoft.EntityFrameworkCore.Migrations;

namespace Habr.Data.Migrations
{
    public partial class migrtionnam347 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Articles");
        }
    }
}
