using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Staffs",
                newName: "Staff_ID");

            migrationBuilder.RenameColumn(
                name: "PersonNationalId",
                table: "People",
                newName: "PersonNational_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Staff_ID",
                table: "Staffs",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "PersonNational_ID",
                table: "People",
                newName: "PersonNationalId");
        }
    }
}
