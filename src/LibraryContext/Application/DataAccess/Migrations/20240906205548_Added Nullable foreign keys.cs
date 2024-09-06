using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inanna.LibraryContext.Application.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "Volumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cover_Path",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cover_ContentType",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "Volumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cover_Path",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cover_ContentType",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
