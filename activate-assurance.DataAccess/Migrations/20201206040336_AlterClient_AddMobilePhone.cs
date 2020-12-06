using Microsoft.EntityFrameworkCore.Migrations;

namespace activate_assurance.DataAccess.Migrations
{
    public partial class AlterClient_AddMobilePhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mobilePhone",
                table: "Clients",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mobilePhone",
                table: "Clients");
        }
    }
}
