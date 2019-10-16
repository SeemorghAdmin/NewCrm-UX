using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class Staffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrgStaffNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    TeleNumber = table.Column<string>(maxLength: 12, nullable: true),
                    EduDegree = table.Column<string>(maxLength: 50, nullable: true),
                    EduField = table.Column<string>(maxLength: 50, nullable: true),
                    PersonNationalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_People_PersonNationalId",
                        column: x => x.PersonNationalId,
                        principalTable: "People",
                        principalColumn: "PersonNationalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PersonNationalId",
                table: "Staffs",
                column: "PersonNationalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");
        }
    }
}
