using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class FilmMemberDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FilmMember",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FilmMember");
        }
    }
}
