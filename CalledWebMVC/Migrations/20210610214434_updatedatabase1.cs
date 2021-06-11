using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class updatedatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Functionary",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12) CHARACTER SET utf8mb4",
                oldMaxLength: 12,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Functionary",
                type: "varchar(12) CHARACTER SET utf8mb4",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);
        }
    }
}
