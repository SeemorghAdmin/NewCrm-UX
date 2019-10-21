using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditPersonalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_People_PersonNationalId",
                table: "TicketingChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_People_PersonNationalId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PersonNationalId",
                table: "Tickets",
                newName: "PersonNational_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PersonNationalId",
                table: "Tickets",
                newName: "IX_Tickets_PersonNational_ID");

            migrationBuilder.RenameColumn(
                name: "PersonNationalId",
                table: "TicketingChats",
                newName: "PersonNational_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketingChats_PersonNationalId",
                table: "TicketingChats",
                newName: "IX_TicketingChats_PersonNational_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_People_PersonNational_ID",
                table: "TicketingChats",
                column: "PersonNational_ID",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_People_PersonNational_ID",
                table: "Tickets",
                column: "PersonNational_ID",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_People_PersonNational_ID",
                table: "TicketingChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_People_PersonNational_ID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PersonNational_ID",
                table: "Tickets",
                newName: "PersonNationalId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PersonNational_ID",
                table: "Tickets",
                newName: "IX_Tickets_PersonNationalId");

            migrationBuilder.RenameColumn(
                name: "PersonNational_ID",
                table: "TicketingChats",
                newName: "PersonNationalId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketingChats_PersonNational_ID",
                table: "TicketingChats",
                newName: "IX_TicketingChats_PersonNationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_People_PersonNationalId",
                table: "TicketingChats",
                column: "PersonNationalId",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_People_PersonNationalId",
                table: "Tickets",
                column: "PersonNationalId",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
