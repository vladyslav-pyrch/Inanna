using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Migrations
{
    /// <inheritdoc />
    public partial class Pageprojectionisreconfigured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                columns: new[] { "Number", "ChapterId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");
        }
    }
}
