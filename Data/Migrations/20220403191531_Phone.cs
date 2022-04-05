using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Data.Migrations
{
    public partial class Phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Tickets");
        }
    }
}
