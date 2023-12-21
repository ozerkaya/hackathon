using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonDAL.Migrations
{
    public partial class ver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gamer1Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gamer2Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gamer1Point = table.Column<int>(type: "int", nullable: false),
                    Gamer2Point = table.Column<int>(type: "int", nullable: false),
                    Gamer1Question = table.Column<int>(type: "int", nullable: false),
                    Gamer2Question = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
