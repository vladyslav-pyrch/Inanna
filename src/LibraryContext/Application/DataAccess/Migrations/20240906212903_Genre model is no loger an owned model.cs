using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inanna.LibraryContext.Application.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Genremodelisnologeranownedmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Mangas_MangaModelId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MangaModelId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "GenreModelMangaModel",
                columns: table => new
                {
                    GenresName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MangasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModelMangaModel", x => new { x.GenresName, x.MangasId });
                    table.ForeignKey(
                        name: "FK_GenreModelMangaModel_Genres_GenresName",
                        column: x => x.GenresName,
                        principalTable: "Genres",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreModelMangaModel_Mangas_MangasId",
                        column: x => x.MangasId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreModelMangaModel_MangasId",
                table: "GenreModelMangaModel",
                column: "MangasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreModelMangaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "MangaModelId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                columns: new[] { "MangaModelId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Mangas_MangaModelId",
                table: "Genres",
                column: "MangaModelId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
