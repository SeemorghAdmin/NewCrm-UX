using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfCreation",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Closure",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CommentTime",
                table: "TicketingChats",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreation",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Closure",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentTime",
                table: "TicketingChats",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
