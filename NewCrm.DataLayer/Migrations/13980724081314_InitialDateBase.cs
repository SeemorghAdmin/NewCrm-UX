using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class InitialDateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonNationalId = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    NationalCardSerial = table.Column<string>(maxLength: 12, nullable: true),
                    ShenasNum = table.Column<string>(maxLength: 12, nullable: true),
                    ShenasSerial = table.Column<string>(maxLength: 12, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Role1 = table.Column<int>(nullable: false),
                    Role2 = table.Column<int>(nullable: false),
                    Role3 = table.Column<int>(nullable: false),
                    Role4 = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonNationalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
