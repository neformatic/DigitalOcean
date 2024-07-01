using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalOcean.Migrations
{
    public partial class AddedSurnameproptoUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");
        }
    }
}
