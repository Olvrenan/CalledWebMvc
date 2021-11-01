using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class NparaN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ajudante1",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Ajudante2",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Task",
                table: "Functionary");

            migrationBuilder.CreateTable(
                name: "FuncionaryTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    FunctionaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionaryTasks", x => new { x.FunctionaryId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_FuncionaryTasks_Functionary_FunctionaryId",
                        column: x => x.FunctionaryId,
                        principalTable: "Functionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionaryTasks_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionaryTasks_TaskId",
                table: "FuncionaryTasks",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionaryTasks");

            migrationBuilder.AddColumn<string>(
                name: "Ajudante1",
                table: "Task",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ajudante2",
                table: "Task",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "Functionary",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
