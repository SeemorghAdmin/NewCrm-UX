using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_Tickets_TicketID",
                table: "TicketingChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Tickets",
                newName: "Service_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ServiceId",
                table: "Tickets",
                newName: "IX_Tickets_Service_ID");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "TicketingChats",
                newName: "Ticket_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketingChats_TicketID",
                table: "TicketingChats",
                newName: "IX_TicketingChats_Ticket_ID");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ServiceType_ID",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_Tickets_Ticket_ID",
                table: "TicketingChats",
                column: "Ticket_ID",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Services_Service_ID",
                table: "Tickets",
                column: "Service_ID",
                principalTable: "Services",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketingChats_Tickets_Ticket_ID",
                table: "TicketingChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Services_Service_ID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ServiceType_ID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "TicketID");

            migrationBuilder.RenameColumn(
                name: "Service_ID",
                table: "Tickets",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Service_ID",
                table: "Tickets",
                newName: "IX_Tickets_ServiceId");

            migrationBuilder.RenameColumn(
                name: "Ticket_ID",
                table: "TicketingChats",
                newName: "TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketingChats_Ticket_ID",
                table: "TicketingChats",
                newName: "IX_TicketingChats_TicketID");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketingChats_Tickets_TicketID",
                table: "TicketingChats",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
