using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class developer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_People_PersonNationalId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_PersonNationalId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "PersonNationalId",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "PersonNational_ID",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PersonNational_ID",
                table: "Staffs",
                column: "PersonNational_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_PersonNational_ID",
                table: "Developers",
                column: "PersonNational_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_People_PersonNational_ID",
                table: "Staffs",
                column: "PersonNational_ID",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_People_PersonNational_ID",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_PersonNational_ID",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "PersonNational_ID",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonNationalId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PersonNationalId",
                table: "Staffs",
                column: "PersonNationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_People_PersonNationalId",
                table: "Staffs",
                column: "PersonNationalId",
                principalTable: "People",
                principalColumn: "PersonNational_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
