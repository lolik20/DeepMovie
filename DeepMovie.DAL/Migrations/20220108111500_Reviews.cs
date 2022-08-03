using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeepMovie.DAL.Migrations
{
    public partial class Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Member_MemberID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmMember_Member_MemberID",
                table: "FilmMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Content_PhotoID",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Member_PhotoID",
                table: "Members",
                newName: "IX_Members_PhotoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ImageID = table.Column<int>(nullable: false),
                    FilmID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Content_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Content",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FilmID",
                table: "Reviews",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ImageID",
                table: "Reviews",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Members_MemberID",
                table: "Content",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmMember_Members_MemberID",
                table: "FilmMember",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Content_PhotoID",
                table: "Members",
                column: "PhotoID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Members_MemberID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmMember_Members_MemberID",
                table: "FilmMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Content_PhotoID",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Members_PhotoID",
                table: "Member",
                newName: "IX_Member_PhotoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Member_MemberID",
                table: "Content",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmMember_Member_MemberID",
                table: "FilmMember",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Content_PhotoID",
                table: "Member",
                column: "PhotoID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
