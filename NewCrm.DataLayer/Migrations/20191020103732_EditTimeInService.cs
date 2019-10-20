using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class EditTimeInService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastEditTiame",
                table: "ServiceTypes",
                newName: "LastEditTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastEditTime",
                table: "ServiceTypes",
                newName: "LastEditTiame");
        }
    }
}
