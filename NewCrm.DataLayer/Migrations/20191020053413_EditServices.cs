using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketServices_TicketServiceTypes_TicketServiceTypeId",
                table: "TicketServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketServiceTypes",
                table: "TicketServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketServices",
                table: "TicketServices");

            migrationBuilder.RenameTable(
                name: "TicketServiceTypes",
                newName: "ServiceTypes");

            migrationBuilder.RenameTable(
                name: "TicketServices",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_TicketServices_TicketServiceTypeId",
                table: "Services",
                newName: "IX_Services_TicketServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes",
                column: "TicketServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_TicketServiceTypeId",
                table: "Services",
                column: "TicketServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "TicketServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_TicketServiceTypeId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "TicketServiceTypes");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "TicketServices");

            migrationBuilder.RenameIndex(
                name: "IX_Services_TicketServiceTypeId",
                table: "TicketServices",
                newName: "IX_TicketServices_TicketServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketServiceTypes",
                table: "TicketServiceTypes",
                column: "TicketServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketServices",
                table: "TicketServices",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketServices_TicketServiceTypes_TicketServiceTypeId",
                table: "TicketServices",
                column: "TicketServiceTypeId",
                principalTable: "TicketServiceTypes",
                principalColumn: "TicketServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
