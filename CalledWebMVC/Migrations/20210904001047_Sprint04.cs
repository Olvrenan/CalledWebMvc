using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class Sprint04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sprint",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_SprintId",
                table: "Task",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Sprint_SprintId",
                table: "Task",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Sprint_SprintId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_SprintId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "Sprint",
                table: "Task",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
