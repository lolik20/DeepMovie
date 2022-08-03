using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeepMovie.DAL.Migrations
{
    public partial class RebuildPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Photo_PhotoID",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Films");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: true),
                    FilmID = table.Column<int>(nullable: true),
                    ContentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Content_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_FilmID",
                table: "Content",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_MemberID",
                table: "Content",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Content_PhotoID",
                table: "Member",
                column: "PhotoID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Content_PhotoID",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Films",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmID = table.Column<int>(type: "integer", nullable: true),
                    MemberID = table.Column<int>(type: "integer", nullable: true),
                    URL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photo_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_FilmID",
                table: "Photo",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_MemberID",
                table: "Photo",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Photo_PhotoID",
                table: "Member",
                column: "PhotoID",
                principalTable: "Photo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
