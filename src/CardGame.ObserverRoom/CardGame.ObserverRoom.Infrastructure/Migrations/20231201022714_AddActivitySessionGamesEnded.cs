using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.ObserverRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivitySessionGamesEnded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfEndedGames",
                table: "ActivitySession",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfEndedGames",
                table: "ActivitySession");
        }
    }
}
