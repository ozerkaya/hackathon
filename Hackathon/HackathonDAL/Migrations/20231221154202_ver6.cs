using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonDAL.Migrations
{
    public partial class ver6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gamer1Finish",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gamer2Finish",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gamer1Finish",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Gamer2Finish",
                table: "Games");
        }
    }
}
