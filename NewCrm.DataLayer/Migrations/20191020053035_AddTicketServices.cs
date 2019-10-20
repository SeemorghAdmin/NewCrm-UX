using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class AddTicketServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketServiceTypes",
                columns: table => new
                {
                    TicketServiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    EnName = table.Column<string>(maxLength: 100, nullable: true),
                    FaName = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTiame = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketServiceTypes", x => x.TicketServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TicketServices",
                columns: table => new
                {
                    ServicesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketServiceTypeId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    EnName = table.Column<string>(maxLength: 100, nullable: true),
                    FaName = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketServices", x => x.ServicesId);
                    table.ForeignKey(
                        name: "FK_TicketServices_TicketServiceTypes_TicketServiceTypeId",
                        column: x => x.TicketServiceTypeId,
                        principalTable: "TicketServiceTypes",
                        principalColumn: "TicketServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketServices_TicketServiceTypeId",
                table: "TicketServices",
                column: "TicketServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketServices");

            migrationBuilder.DropTable(
                name: "TicketServiceTypes");
        }
    }
}
