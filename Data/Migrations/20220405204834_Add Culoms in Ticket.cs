using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore.Data.Migrations
{
    public partial class AddCulomsinTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CableLength",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CableType",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoresNumbers",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestType",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wavelength",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ticketType",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CableLength",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CableType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CoresNumbers",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TestType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Wavelength",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "Tickets");
        }
    }
}
