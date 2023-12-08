using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.ObserverRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameState = table.Column<int>(type: "integer", nullable: false),
                    ZuckerbergStrategy = table.Column<int>(type: "integer", nullable: false),
                    MuskStrategy = table.Column<int>(type: "integer", nullable: false),
                    JsonDeck = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
