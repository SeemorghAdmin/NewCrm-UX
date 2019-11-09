using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class AddSeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "TicketingChats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "TicketingChats");
        }
    }
}
