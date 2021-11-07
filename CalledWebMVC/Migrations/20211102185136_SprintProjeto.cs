using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class SprintProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Projeto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_SprintId",
                table: "Projeto",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Sprint_SprintId",
                table: "Projeto",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Sprint_SprintId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_SprintId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Projeto");
        }
    }
}
