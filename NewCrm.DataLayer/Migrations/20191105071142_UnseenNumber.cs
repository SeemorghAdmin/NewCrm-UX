using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class UnseenNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnseenNumber",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnseenNumber",
                table: "Tickets");
        }
    }
}
