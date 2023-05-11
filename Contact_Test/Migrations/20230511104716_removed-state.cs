using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Test.Migrations
{
    public partial class removedstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
