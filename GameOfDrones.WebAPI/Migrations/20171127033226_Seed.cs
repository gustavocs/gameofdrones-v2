using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameOfDrones.WebAPI.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[3] { "MoveId", "Name", "KillsMoveId" };

            migrationBuilder.InsertData("Move", columns, new object[3] { 1, "Paper", 1 });
            migrationBuilder.InsertData("Move", columns, new object[3] { 2, "Scissors", 2 });
            migrationBuilder.InsertData("Move", columns, new object[3] { 3, "Rock", 3 });

						migrationBuilder.UpdateData("Move", "MoveId", 1, "KillsMoveId",  3);
						migrationBuilder.UpdateData("Move", "MoveId", 2, "KillsMoveId",  1);
						migrationBuilder.UpdateData("Move", "MoveId", 3, "KillsMoveId",  2);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Move\"");
        }
    }
}
