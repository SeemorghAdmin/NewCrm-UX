using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCrm.DataLayer.Migrations
{
    public partial class AccessModifier_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IStering",
                table: "AccessModifiers",
                newName: "IString");

            migrationBuilder.RenameColumn(
                name: "Cat",
                table: "AccessModifiers",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccessModifiers",
                newName: "AccessModifier_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IString",
                table: "AccessModifiers",
                newName: "IStering");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "AccessModifiers",
                newName: "Cat");

            migrationBuilder.RenameColumn(
                name: "AccessModifier_ID",
                table: "AccessModifiers",
                newName: "Id");
        }
    }
}
