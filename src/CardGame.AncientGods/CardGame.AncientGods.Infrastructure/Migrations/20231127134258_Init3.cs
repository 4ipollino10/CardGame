using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.AncientGods.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SendDecks",
                table: "SendDecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerChoices",
                table: "PlayerChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "SendDecks",
                newName: "SendDeck");

            migrationBuilder.RenameTable(
                name: "PlayerChoices",
                newName: "PlayerChoice");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendDeck",
                table: "SendDeck",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerChoice",
                table: "PlayerChoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SendDeck",
                table: "SendDeck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerChoice",
                table: "PlayerChoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "SendDeck",
                newName: "SendDecks");

            migrationBuilder.RenameTable(
                name: "PlayerChoice",
                newName: "PlayerChoices");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendDecks",
                table: "SendDecks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerChoices",
                table: "PlayerChoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");
        }
    }
}
