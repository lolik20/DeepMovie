using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class IsImmersive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImmersive",
                table: "Films",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImmersive",
                table: "Films");
        }
    }
}
