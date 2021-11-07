using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class funcionariotaskreturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FunctionaryId",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_FunctionaryId",
                table: "Task",
                column: "FunctionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Functionary_FunctionaryId",
                table: "Task",
                column: "FunctionaryId",
                principalTable: "Functionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Functionary_FunctionaryId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_FunctionaryId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "FunctionaryId",
                table: "Task");
        }
    }
}
