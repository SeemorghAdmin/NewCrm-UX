using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class AddDeveloperTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeveloperTickets",
                columns: table => new
                {
                    DeveloperTicket_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonNational_ID = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Resiver = table.Column<string>(nullable: true),
                    Closure = table.Column<string>(nullable: true),
                    UnseenNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTickets", x => x.DeveloperTicket_ID);
                    table.ForeignKey(
                        name: "FK_DeveloperTickets_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicketChats",
                columns: table => new
                {
                    DeveloperTicketChat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeveloperTicket_ID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CommentTime = table.Column<string>(nullable: true),
                    PersonNational_ID = table.Column<string>(nullable: true),
                    Confidential = table.Column<bool>(nullable: false),
                    Resiver = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Seen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicketChats", x => x.DeveloperTicketChat_ID);
                    table.ForeignKey(
                        name: "FK_DeveloperTicketChats_DeveloperTickets_DeveloperTicket_ID",
                        column: x => x.DeveloperTicket_ID,
                        principalTable: "DeveloperTickets",
                        principalColumn: "DeveloperTicket_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicketChats_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperTicketChats_People_Resiver",
                        column: x => x.Resiver,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperTicketChats_People_Sender",
                        column: x => x.Sender,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicketChats_DeveloperTicket_ID",
                table: "DeveloperTicketChats",
                column: "DeveloperTicket_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicketChats_PersonNational_ID",
                table: "DeveloperTicketChats",
                column: "PersonNational_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicketChats_Resiver",
                table: "DeveloperTicketChats",
                column: "Resiver");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicketChats_Sender",
                table: "DeveloperTicketChats",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTickets_PersonNational_ID",
                table: "DeveloperTickets",
                column: "PersonNational_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTicketChats");

            migrationBuilder.DropTable(
                name: "DeveloperTickets");
        }
    }
}
