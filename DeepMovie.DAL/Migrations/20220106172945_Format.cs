using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class Format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "Films");
        }
    }
}
