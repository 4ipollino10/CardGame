using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.ObserverRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ActivitySessionConfiguration_ActivitySessionId",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySessionConfiguration",
                table: "ActivitySessionConfiguration");

            migrationBuilder.RenameTable(
                name: "ActivitySessionConfiguration",
                newName: "ActivitySession");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySession",
                table: "ActivitySession",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ActivitySession_ActivitySessionId",
                table: "Game",
                column: "ActivitySessionId",
                principalTable: "ActivitySession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ActivitySession_ActivitySessionId",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySession",
                table: "ActivitySession");

            migrationBuilder.RenameTable(
                name: "ActivitySession",
                newName: "ActivitySessionConfiguration");

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
    }
}
