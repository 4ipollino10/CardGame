using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.AncientGods.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSendDeckEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "SendDeck");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendDeck",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendDeck", x => x.Id);
                });
        }
    }
}
