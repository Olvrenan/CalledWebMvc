using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class taskajustecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assingn",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sprint",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Functionary",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Sprint",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "Assingn",
                table: "Task",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Functionary",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
