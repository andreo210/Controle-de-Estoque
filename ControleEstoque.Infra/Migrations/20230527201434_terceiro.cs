using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class terceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoPessoaId",
                table: "fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_fornecedor_TipoPessoaId",
                table: "fornecedor");

            migrationBuilder.RenameColumn(
                name: "TipoPessoaId",
                table: "fornecedor",
                newName: "TipoFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_TipoFornecedorId",
                table: "fornecedor",
                column: "TipoFornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "fornecedor",
                column: "TipoFornecedorId",
                principalTable: "tbTipoFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_fornecedor_TipoFornecedorId",
                table: "fornecedor");

            migrationBuilder.RenameColumn(
                name: "TipoFornecedorId",
                table: "fornecedor",
                newName: "TipoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_TipoPessoaId",
                table: "fornecedor",
                column: "TipoPessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoPessoaId",
                table: "fornecedor",
                column: "TipoPessoaId",
                principalTable: "tbTipoFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
