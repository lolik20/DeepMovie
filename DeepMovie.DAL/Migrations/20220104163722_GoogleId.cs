using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class GoogleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleID",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleID",
                table: "Users");
        }
    }
}
