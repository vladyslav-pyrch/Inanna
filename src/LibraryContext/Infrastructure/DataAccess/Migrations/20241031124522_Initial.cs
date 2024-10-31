using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoredEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AggregateRootIdType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AggregateRootId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoredEvents_Position",
                table: "StoredEvents",
                column: "Position",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoredEvents");
        }
    }
}
