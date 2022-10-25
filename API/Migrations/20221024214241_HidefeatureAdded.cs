using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class HidefeatureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hidden",
                table: "Gigs",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Gigs");
        }
    }
}
