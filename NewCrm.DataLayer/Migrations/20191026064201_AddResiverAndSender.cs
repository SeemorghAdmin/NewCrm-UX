using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class AddResiverAndSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resiver",
                table: "TicketingChats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "TicketingChats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_Resiver",
                table: "TicketingChats",
                column: "Resiver");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_Sender",
                table: "TicketingChats",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_People_Resiver",
                table: "TicketingChats",
                column: "Resiver",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_People_Sender",
                table: "TicketingChats",
                column: "Sender",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_People_Resiver",
                table: "TicketingChats");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_People_Sender",
                table: "TicketingChats");

            migrationBuilder.DropIndex(
                name: "IX_TicketingChats_Resiver",
                table: "TicketingChats");

            migrationBuilder.DropIndex(
                name: "IX_TicketingChats_Sender",
                table: "TicketingChats");

            migrationBuilder.DropColumn(
                name: "Resiver",
                table: "TicketingChats");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "TicketingChats");
        }
    }
}
