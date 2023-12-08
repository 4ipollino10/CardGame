using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.ObserverRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ActivitySessions_ActivitySessionId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySessions",
                table: "ActivitySessions");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "ActivitySessions",
                newName: "ActivitySessionConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ActivitySessionId",
                table: "Game",
                newName: "IX_Game_ActivitySessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySessionConfiguration",
                table: "ActivitySessionConfiguration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ActivitySessionConfiguration_ActivitySessionId",
                table: "Game",
                column: "ActivitySessionId",
                principalTable: "ActivitySessionConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ActivitySessionConfiguration_ActivitySessionId",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySessionConfiguration",
                table: "ActivitySessionConfiguration");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "ActivitySessionConfiguration",
                newName: "ActivitySessions");

            migrationBuilder.RenameIndex(
                name: "IX_Game_ActivitySessionId",
                table: "Games",
                newName: "IX_Games_ActivitySessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySessions",
                table: "ActivitySessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ActivitySessions_ActivitySessionId",
                table: "Games",
                column: "ActivitySessionId",
                principalTable: "ActivitySessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
