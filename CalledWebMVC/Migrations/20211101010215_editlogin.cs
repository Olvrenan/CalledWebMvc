using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class editlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LembrarMe",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LembrarMe",
                table: "Usuario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
