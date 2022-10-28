using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class scoreAvgAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreAvg",
                table: "Ratings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreAvg",
                table: "Ratings");
        }
    }
}
