using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.ObserverRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameState",
                table: "Games",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ActivitySessionGuid",
                table: "Games",
                newName: "ActivitySessionId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ActivitySessions",
                newName: "ZuckerbergStrategy");

            migrationBuilder.AddColumn<int>(
                name: "GameResult",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuskStrategy",
                table: "ActivitySessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ActivitySessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ActivitySessionId",
                table: "Games",
                column: "ActivitySessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ActivitySessions_ActivitySessionId",
                table: "Games",
                column: "ActivitySessionId",
                principalTable: "ActivitySessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ActivitySessions_ActivitySessionId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ActivitySessionId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameResult",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MuskStrategy",
                table: "ActivitySessions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ActivitySessions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Games",
                newName: "GameState");

            migrationBuilder.RenameColumn(
                name: "ActivitySessionId",
                table: "Games",
                newName: "ActivitySessionGuid");

            migrationBuilder.RenameColumn(
                name: "ZuckerbergStrategy",
                table: "ActivitySessions",
                newName: "Type");
        }
    }
}
