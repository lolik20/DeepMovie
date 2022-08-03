using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepMovie.DAL.Migrations
{
    public partial class Funds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FundRaised",
                table: "Films",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FundTotal",
                table: "Films",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FundRaised",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FundTotal",
                table: "Films");
        }
    }
}
