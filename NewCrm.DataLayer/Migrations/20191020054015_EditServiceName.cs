using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditServiceName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_TicketServiceTypeId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "TicketServiceTypeId",
                table: "ServiceTypes",
                newName: "ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "TicketServiceTypeId",
                table: "Services",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_TicketServiceTypeId",
                table: "Services",
                newName: "IX_Services_ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceTypes",
                newName: "TicketServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "Services",
                newName: "TicketServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                newName: "IX_Services_TicketServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_TicketServiceTypeId",
                table: "Services",
                column: "TicketServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "TicketServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
