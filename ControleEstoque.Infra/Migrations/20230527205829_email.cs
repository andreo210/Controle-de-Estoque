using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_fornecedor_id_fornecedor",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbContato_fornecedor_IdFornecedor",
                table: "tbContato");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEndereco_fornecedor_IdFornecedor",
                table: "tbEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fornecedor",
                table: "fornecedor");

            migrationBuilder.RenameTable(
                name: "fornecedor",
                newName: "tbFornecedor");

            migrationBuilder.RenameColumn(
                name: "razao_social",
                table: "tbFornecedor",
                newName: "Razao_social");

            migrationBuilder.RenameColumn(
                name: "num_documento",
                table: "tbFornecedor",
                newName: "Num_documento");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tbFornecedor",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_fornecedor_TipoFornecedorId",
                table: "tbFornecedor",
                newName: "IX_tbFornecedor_TipoFornecedorId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tbFornecedor",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbFornecedor",
                table: "tbFornecedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tbFornecedor_id_fornecedor",
                table: "produto",
                column: "id_fornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbContato_tbFornecedor_IdFornecedor",
                table: "tbContato",
                column: "IdFornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco",
                column: "IdFornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbFornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "tbFornecedor",
                column: "TipoFornecedorId",
                principalTable: "tbTipoFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_tbFornecedor_id_fornecedor",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbContato_tbFornecedor_IdFornecedor",
                table: "tbContato");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tbFornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "tbFornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbFornecedor",
                table: "tbFornecedor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tbFornecedor");

            migrationBuilder.RenameTable(
                name: "tbFornecedor",
                newName: "fornecedor");

            migrationBuilder.RenameColumn(
                name: "Razao_social",
                table: "fornecedor",
                newName: "razao_social");

            migrationBuilder.RenameColumn(
                name: "Num_documento",
                table: "fornecedor",
                newName: "num_documento");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "fornecedor",
                newName: "nome");

            migrationBuilder.RenameIndex(
                name: "IX_tbFornecedor_TipoFornecedorId",
                table: "fornecedor",
                newName: "IX_fornecedor_TipoFornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fornecedor",
                table: "fornecedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoFornecedorId",
                table: "fornecedor",
                column: "TipoFornecedorId",
                principalTable: "tbTipoFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_fornecedor_id_fornecedor",
                table: "produto",
                column: "id_fornecedor",
                principalTable: "fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbContato_fornecedor_IdFornecedor",
                table: "tbContato",
                column: "IdFornecedor",
                principalTable: "fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbEndereco_fornecedor_IdFornecedor",
                table: "tbEndereco",
                column: "IdFornecedor",
                principalTable: "fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
