using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeepMovie.DAL.Migrations
{
    public partial class FilmCategoryPhotoMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Sound = table.Column<string>(nullable: true),
                    TotalBudget = table.Column<int>(nullable: false),
                    USAFees = table.Column<int>(nullable: false),
                    TotalFees = table.Column<int>(nullable: false),
                    RussiaFees = table.Column<int>(nullable: false),
                    TotalPremiere = table.Column<DateTime>(nullable: false),
                    RussiaPremiere = table.Column<DateTime>(nullable: false),
                    AgeRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DonationStages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: false),
                    FilmID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationStages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonationStages_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmCategories",
                columns: table => new
                {
                    FilmID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCategories", x => new { x.FilmID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_FilmCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCategories_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmMember",
                columns: table => new
                {
                    FilmID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    MemberRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmMember", x => new { x.FilmID, x.MemberID });
                    table.ForeignKey(
                        name: "FK_FilmMember_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: true),
                    FilmID = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    PhotoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Member_Photo_PhotoID",
                        column: x => x.PhotoID,
                        principalTable: "Photo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationStages_FilmID",
                table: "DonationStages",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_CategoryID",
                table: "FilmCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmMember_MemberID",
                table: "FilmMember",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_PhotoID",
                table: "Member",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_FilmID",
                table: "Photo",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_MemberID",
                table: "Photo",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmMember_Member_MemberID",
                table: "FilmMember",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Member_MemberID",
                table: "Photo",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Films_FilmID",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Member_MemberID",
                table: "Photo");

            migrationBuilder.DropTable(
                name: "DonationStages");

            migrationBuilder.DropTable(
                name: "FilmCategories");

            migrationBuilder.DropTable(
                name: "FilmMember");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Photo");
        }
    }
}
