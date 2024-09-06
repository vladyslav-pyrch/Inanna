using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inanna.LibraryContext.Application.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Genrenameismadeprimarykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MangaModelId",
                table: "Genres",
                column: "MangaModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MangaModelId",
                table: "Genres");

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
        }
    }
}
