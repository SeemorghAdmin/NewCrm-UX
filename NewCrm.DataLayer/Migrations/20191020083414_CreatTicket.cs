using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class CreatTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PersonNationalId = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Closure = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_People_PersonNationalId",
                        column: x => x.PersonNationalId,
                        principalTable: "People",
                        principalColumn: "PersonNationalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServicesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketingChats",
                columns: table => new
                {
                    TicketingChatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    PersonNationalId = table.Column<string>(nullable: true),
                    Confidential = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingChats", x => x.TicketingChatId);
                    table.ForeignKey(
                        name: "FK_TicketingChats_People_PersonNationalId",
                        column: x => x.PersonNationalId,
                        principalTable: "People",
                        principalColumn: "PersonNationalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingChats_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_PersonNationalId",
                table: "TicketingChats",
                column: "PersonNationalId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_TicketID",
                table: "TicketingChats",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonNationalId",
                table: "Tickets",
                column: "PersonNationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ServiceId",
                table: "Tickets",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketingChats");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
