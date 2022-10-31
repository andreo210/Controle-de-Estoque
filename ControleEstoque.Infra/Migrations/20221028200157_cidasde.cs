using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class cidasde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cidade_nome",
                table: "Cidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cidade_nome",
                table: "Cidade",
                column: "nome",
                unique: true);
        }
    }
}
