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

            migrationBuilder.Sql("ALTER TABLE \"Move\" DISABLE TRIGGER ALL");

            migrationBuilder.InsertData("Move", columns, new object[3] { 1, "Paper", 3 });
            migrationBuilder.InsertData("Move", columns, new object[3] { 2, "Scissors", 1 });
            migrationBuilder.InsertData("Move", columns, new object[3] { 3, "Rock", 2 });

            migrationBuilder.Sql("ALTER TABLE \"Move\" ENABLE TRIGGER ALL");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Move\"");
        }
    }
}
