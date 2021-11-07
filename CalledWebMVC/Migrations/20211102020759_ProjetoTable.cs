using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class ProjetoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Sprint",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_ProjetoId",
                table: "Sprint",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Projeto_ProjetoId",
                table: "Sprint",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Projeto_ProjetoId",
                table: "Sprint");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Sprint_ProjetoId",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Sprint");
        }
    }
}
