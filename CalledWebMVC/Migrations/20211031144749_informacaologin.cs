using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalledWebMVC.Migrations
{
    public partial class informacaologin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformacaoLogin",
                columns: table => new
                {
                    InformacaoLoginId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnderecoIP = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    Horario = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoLogin", x => x.InformacaoLoginId);
                    table.ForeignKey(
                        name: "FK_InformacaoLogin_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacaoLogin_UsuarioId",
                table: "InformacaoLogin",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacaoLogin");
        }
    }
}
