using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Ticket_ID");

            migrationBuilder.RenameColumn(
                name: "TicketingChatId",
                table: "TicketingChats",
                newName: "TicketingChat_ID");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceTypes",
                newName: "ServiceType_ID");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "Services",
                newName: "Services_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceType_ID",
                table: "Services",
                column: "ServiceType_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceType_ID",
                table: "Services",
                column: "ServiceType_ID",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceType_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceType_ID",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceType_ID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Ticket_ID",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "TicketingChat_ID",
                table: "TicketingChats",
                newName: "TicketingChatId");

            migrationBuilder.RenameColumn(
                name: "ServiceType_ID",
                table: "ServiceTypes",
                newName: "ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "Services_ID",
                table: "Services",
                newName: "ServicesId");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
