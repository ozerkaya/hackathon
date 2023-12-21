using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonDAL.Migrations
{
    public partial class ver8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChoiseA",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoiseB",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoiseC",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoiseD",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoiseA",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ChoiseB",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ChoiseC",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ChoiseD",
                table: "Questions");
        }
    }
}
