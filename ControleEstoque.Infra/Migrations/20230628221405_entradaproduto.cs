using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class entradaproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entrada_produto_produto_id_produto",
                table: "entrada_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_inventario_estoque_produto_id_produto",
                table: "inventario_estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_perfil_usuario_perfil_PerfisId",
                table: "perfil_usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_grupoProduto_id_grupo",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_locaisArmazenamento_id_local_aramazenamento",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_marca",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_tb_unidade_medida_id_unidade_medida",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_tbFornecedor_id_fornecedor",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_saida_produto_produto_id_produto",
                table: "saida_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_unidade_medida",
                table: "tb_unidade_medida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_MarcasProdutos",
                table: "tb_MarcasProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_locaisArmazenamento",
                table: "tb_locaisArmazenamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_grupoProduto",
                table: "tb_grupoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saida_produto",
                table: "saida_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_perfil",
                table: "perfil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventario_estoque",
                table: "inventario_estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entrada_produto",
                table: "entrada_produto");

            migrationBuilder.RenameTable(
                name: "tb_unidade_medida",
                newName: "tbUnidade_medida");

            migrationBuilder.RenameTable(
                name: "tb_MarcasProdutos",
                newName: "tbMarcasProdutos");

            migrationBuilder.RenameTable(
                name: "tb_locaisArmazenamento",
                newName: "tbLocaisArmazenamento");

            migrationBuilder.RenameTable(
                name: "tb_grupoProduto",
                newName: "tbGrupoProduto");

            migrationBuilder.RenameTable(
                name: "saida_produto",
                newName: "tbSaida_produto");

            migrationBuilder.RenameTable(
                name: "produto",
                newName: "tbProduto");

            migrationBuilder.RenameTable(
                name: "perfil",
                newName: "tbPerfil");

            migrationBuilder.RenameTable(
                name: "inventario_estoque",
                newName: "tbInventario_estoque");

            migrationBuilder.RenameTable(
                name: "entrada_produto",
                newName: "tbEntrada_produto");

            migrationBuilder.RenameIndex(
                name: "IX_saida_produto_id_produto",
                table: "tbSaida_produto",
                newName: "IX_tbSaida_produto_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_produto_id_unidade_medida",
                table: "tbProduto",
                newName: "IX_tbProduto_id_unidade_medida");

            migrationBuilder.RenameIndex(
                name: "IX_produto_id_marca",
                table: "tbProduto",
                newName: "IX_tbProduto_id_marca");

            migrationBuilder.RenameIndex(
                name: "IX_produto_id_local_aramazenamento",
                table: "tbProduto",
                newName: "IX_tbProduto_id_local_aramazenamento");

            migrationBuilder.RenameIndex(
                name: "IX_produto_id_grupo",
                table: "tbProduto",
                newName: "IX_tbProduto_id_grupo");

            migrationBuilder.RenameIndex(
                name: "IX_produto_id_fornecedor",
                table: "tbProduto",
                newName: "IX_tbProduto_id_fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_inventario_estoque_id_produto",
                table: "tbInventario_estoque",
                newName: "IX_tbInventario_estoque_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_entrada_produto_id_produto",
                table: "tbEntrada_produto",
                newName: "IX_tbEntrada_produto_id_produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbUnidade_medida",
                table: "tbUnidade_medida",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbMarcasProdutos",
                table: "tbMarcasProdutos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbLocaisArmazenamento",
                table: "tbLocaisArmazenamento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbGrupoProduto",
                table: "tbGrupoProduto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbSaida_produto",
                table: "tbSaida_produto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbProduto",
                table: "tbProduto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbPerfil",
                table: "tbPerfil",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbInventario_estoque",
                table: "tbInventario_estoque",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbEntrada_produto",
                table: "tbEntrada_produto",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_perfil_usuario_tbPerfil_PerfisId",
                table: "perfil_usuario",
                column: "PerfisId",
                principalTable: "tbPerfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco",
                column: "IdFornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbEntrada_produto_tbProduto_id_produto",
                table: "tbEntrada_produto",
                column: "id_produto",
                principalTable: "tbProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbInventario_estoque_tbProduto_id_produto",
                table: "tbInventario_estoque",
                column: "id_produto",
                principalTable: "tbProduto",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbFornecedor_id_fornecedor",
                table: "tbProduto",
                column: "id_fornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbGrupoProduto_id_grupo",
                table: "tbProduto",
                column: "id_grupo",
                principalTable: "tbGrupoProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbLocaisArmazenamento_id_local_aramazenamento",
                table: "tbProduto",
                column: "id_local_aramazenamento",
                principalTable: "tbLocaisArmazenamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbMarcasProdutos_id_marca",
                table: "tbProduto",
                column: "id_marca",
                principalTable: "tbMarcasProdutos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbUnidade_medida_id_unidade_medida",
                table: "tbProduto",
                column: "id_unidade_medida",
                principalTable: "tbUnidade_medida",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbSaida_produto_tbProduto_id_produto",
                table: "tbSaida_produto",
                column: "id_produto",
                principalTable: "tbProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_perfil_usuario_tbPerfil_PerfisId",
                table: "perfil_usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEntrada_produto_tbProduto_id_produto",
                table: "tbEntrada_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbInventario_estoque_tbProduto_id_produto",
                table: "tbInventario_estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbFornecedor_id_fornecedor",
                table: "tbProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbGrupoProduto_id_grupo",
                table: "tbProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbLocaisArmazenamento_id_local_aramazenamento",
                table: "tbProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbMarcasProdutos_id_marca",
                table: "tbProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbUnidade_medida_id_unidade_medida",
                table: "tbProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_tbSaida_produto_tbProduto_id_produto",
                table: "tbSaida_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbUnidade_medida",
                table: "tbUnidade_medida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbSaida_produto",
                table: "tbSaida_produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbProduto",
                table: "tbProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbPerfil",
                table: "tbPerfil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbMarcasProdutos",
                table: "tbMarcasProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbLocaisArmazenamento",
                table: "tbLocaisArmazenamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbInventario_estoque",
                table: "tbInventario_estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbGrupoProduto",
                table: "tbGrupoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbEntrada_produto",
                table: "tbEntrada_produto");

            migrationBuilder.RenameTable(
                name: "tbUnidade_medida",
                newName: "tb_unidade_medida");

            migrationBuilder.RenameTable(
                name: "tbSaida_produto",
                newName: "saida_produto");

            migrationBuilder.RenameTable(
                name: "tbProduto",
                newName: "produto");

            migrationBuilder.RenameTable(
                name: "tbPerfil",
                newName: "perfil");

            migrationBuilder.RenameTable(
                name: "tbMarcasProdutos",
                newName: "tb_MarcasProdutos");

            migrationBuilder.RenameTable(
                name: "tbLocaisArmazenamento",
                newName: "tb_locaisArmazenamento");

            migrationBuilder.RenameTable(
                name: "tbInventario_estoque",
                newName: "inventario_estoque");

            migrationBuilder.RenameTable(
                name: "tbGrupoProduto",
                newName: "tb_grupoProduto");

            migrationBuilder.RenameTable(
                name: "tbEntrada_produto",
                newName: "entrada_produto");

            migrationBuilder.RenameIndex(
                name: "IX_tbSaida_produto_id_produto",
                table: "saida_produto",
                newName: "IX_saida_produto_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduto_id_unidade_medida",
                table: "produto",
                newName: "IX_produto_id_unidade_medida");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduto_id_marca",
                table: "produto",
                newName: "IX_produto_id_marca");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduto_id_local_aramazenamento",
                table: "produto",
                newName: "IX_produto_id_local_aramazenamento");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduto_id_grupo",
                table: "produto",
                newName: "IX_produto_id_grupo");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduto_id_fornecedor",
                table: "produto",
                newName: "IX_produto_id_fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_tbInventario_estoque_id_produto",
                table: "inventario_estoque",
                newName: "IX_inventario_estoque_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_tbEntrada_produto_id_produto",
                table: "entrada_produto",
                newName: "IX_entrada_produto_id_produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_unidade_medida",
                table: "tb_unidade_medida",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saida_produto",
                table: "saida_produto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_perfil",
                table: "perfil",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_MarcasProdutos",
                table: "tb_MarcasProdutos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_locaisArmazenamento",
                table: "tb_locaisArmazenamento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventario_estoque",
                table: "inventario_estoque",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_grupoProduto",
                table: "tb_grupoProduto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entrada_produto",
                table: "entrada_produto",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_entrada_produto_produto_id_produto",
                table: "entrada_produto",
                column: "id_produto",
                principalTable: "produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventario_estoque_produto_id_produto",
                table: "inventario_estoque",
                column: "id_produto",
                principalTable: "produto",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_perfil_usuario_perfil_PerfisId",
                table: "perfil_usuario",
                column: "PerfisId",
                principalTable: "perfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_grupoProduto_id_grupo",
                table: "produto",
                column: "id_grupo",
                principalTable: "tb_grupoProduto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_locaisArmazenamento_id_local_aramazenamento",
                table: "produto",
                column: "id_local_aramazenamento",
                principalTable: "tb_locaisArmazenamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_MarcasProdutos_id_marca",
                table: "produto",
                column: "id_marca",
                principalTable: "tb_MarcasProdutos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tb_unidade_medida_id_unidade_medida",
                table: "produto",
                column: "id_unidade_medida",
                principalTable: "tb_unidade_medida",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_tbFornecedor_id_fornecedor",
                table: "produto",
                column: "id_fornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saida_produto_produto_id_produto",
                table: "saida_produto",
                column: "id_produto",
                principalTable: "produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                table: "tbEndereco",
                column: "IdFornecedor",
                principalTable: "tbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
