using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAspNetCoreServer.DataModel.Migrations
{
    public partial class FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirestName",
                table: "Authors",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "FirestName");
        }
    }
}
