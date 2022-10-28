using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class restricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_grupo",
                table: "produto");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_marca",
                table: "produto",
                column: "id_marca");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_marca",
                table: "produto",
                column: "id_marca",
                principalTable: "tb_MarcasProdutos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_marca",
                table: "produto");

            migrationBuilder.DropIndex(
                name: "IX_produto_id_marca",
                table: "produto");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_grupo",
                table: "produto",
                column: "id_grupo",
                principalTable: "tb_MarcasProdutos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
