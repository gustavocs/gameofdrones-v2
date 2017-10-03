using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameOfDrones.WebAPI.Migrations
{
    public partial class GameWinnerPatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerPlayerId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_WinnerPlayerId",
                table: "Game",
                column: "WinnerPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_WinnerPlayerId",
                table: "Game",
                column: "WinnerPlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_WinnerPlayerId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_WinnerPlayerId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "WinnerPlayerId",
                table: "Game");
        }
    }
}
