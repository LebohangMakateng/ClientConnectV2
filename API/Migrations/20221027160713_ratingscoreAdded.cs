using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ratingscoreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Gigs",
                newName: "Username");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Ratings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Gigs",
                newName: "UserName");
        }
    }
}
