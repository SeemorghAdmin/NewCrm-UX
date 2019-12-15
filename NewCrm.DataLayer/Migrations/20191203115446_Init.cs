using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessModifiers",
                columns: table => new
                {
                    AccessModifier_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    IString = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessModifiers", x => x.AccessModifier_ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonNational_ID = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    NationalCardSerial = table.Column<string>(maxLength: 12, nullable: true),
                    ShenasNum = table.Column<string>(maxLength: 12, nullable: true),
                    ShenasSerial = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Role1 = table.Column<int>(nullable: false),
                    Role2 = table.Column<int>(nullable: false),
                    Role3 = table.Column<int>(nullable: false),
                    Role4 = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    NeedChangePassword = table.Column<bool>(nullable: false),
                    AccessCodes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonNational_ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    Unumber = table.Column<int>(nullable: false),
                    TypeOfFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFileUploads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceType_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    EnName = table.Column<string>(maxLength: 100, nullable: true),
                    FaName = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Developer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonNational_ID = table.Column<string>(maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 12, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Developer_ID);
                    table.ForeignKey(
                        name: "FK_Developers_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Staffs",
                columns: table => new
                {
                    Staff_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    TeleNumber = table.Column<string>(maxLength: 12, nullable: true),
                    EduDegree = table.Column<string>(maxLength: 50, nullable: true),
                    EduField = table.Column<string>(maxLength: 50, nullable: true),
                    PersonNational_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Staff_ID);
                    table.ForeignKey(
                        name: "FK_Staffs_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Services_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceType_ID = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    EnName = table.Column<string>(maxLength: 100, nullable: true),
                    FaName = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Services_ID);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceType_ID",
                        column: x => x.ServiceType_ID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceType_ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticket_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Service_ID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Tickets", x => x.Ticket_ID);
                    table.ForeignKey(
                        name: "FK_Tickets_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Services_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "Services",
                        principalColumn: "Services_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketingChats",
                columns: table => new
                {
                    TicketingChat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ticket_ID = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_TicketingChats", x => x.TicketingChat_ID);
                    table.ForeignKey(
                        name: "FK_TicketingChats_People_PersonNational_ID",
                        column: x => x.PersonNational_ID,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingChats_People_Resiver",
                        column: x => x.Resiver,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingChats_People_Sender",
                        column: x => x.Sender,
                        principalTable: "People",
                        principalColumn: "PersonNational_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingChats_Tickets_Ticket_ID",
                        column: x => x.Ticket_ID,
                        principalTable: "Tickets",
                        principalColumn: "Ticket_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developers_PersonNational_ID",
                table: "Developers",
                column: "PersonNational_ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceType_ID",
                table: "Services",
                column: "ServiceType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PersonNational_ID",
                table: "Staffs",
                column: "PersonNational_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_PersonNational_ID",
                table: "TicketingChats",
                column: "PersonNational_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_Resiver",
                table: "TicketingChats",
                column: "Resiver");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_Sender",
                table: "TicketingChats",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingChats_Ticket_ID",
                table: "TicketingChats",
                column: "Ticket_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonNational_ID",
                table: "Tickets",
                column: "PersonNational_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Service_ID",
                table: "Tickets",
                column: "Service_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessModifiers");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "DeveloperTicketChats");

            migrationBuilder.DropTable(
                name: "ServiceFileUploads");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "TicketingChats");

            migrationBuilder.DropTable(
                name: "DeveloperTickets");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
