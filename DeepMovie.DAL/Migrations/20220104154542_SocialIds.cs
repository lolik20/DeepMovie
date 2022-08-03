using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class SocialIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VkID",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VkID",
                table: "Users");
        }
    }
}
