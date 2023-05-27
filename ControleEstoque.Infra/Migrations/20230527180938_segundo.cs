using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_PessoaEntities_TipoPessoaId",
                table: "fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_tbContato_TipoContatos_TipoContatoId",
                table: "tbContato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoContatos",
                table: "TipoContatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaEntities",
                table: "PessoaEntities");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "fornecedor");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "fornecedor");

            migrationBuilder.RenameTable(
                name: "TipoContatos",
                newName: "tbTipoContato");

            migrationBuilder.RenameTable(
                name: "PessoaEntities",
                newName: "tbTipoFornecedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbTipoContato",
                table: "tbTipoContato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbTipoFornecedor",
                table: "tbTipoFornecedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoPessoaId",
                table: "fornecedor",
                column: "TipoPessoaId",
                principalTable: "tbTipoFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbContato_tbTipoContato_TipoContatoId",
                table: "tbContato",
                column: "TipoContatoId",
                principalTable: "tbTipoContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fornecedor_tbTipoFornecedor_TipoPessoaId",
                table: "fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_tbContato_tbTipoContato_TipoContatoId",
                table: "tbContato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbTipoFornecedor",
                table: "tbTipoFornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbTipoContato",
                table: "tbTipoContato");

            migrationBuilder.RenameTable(
                name: "tbTipoFornecedor",
                newName: "PessoaEntities");

            migrationBuilder.RenameTable(
                name: "tbTipoContato",
                newName: "TipoContatos");

            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "fornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "fornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaEntities",
                table: "PessoaEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoContatos",
                table: "TipoContatos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fornecedor_PessoaEntities_TipoPessoaId",
                table: "fornecedor",
                column: "TipoPessoaId",
                principalTable: "PessoaEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbContato_TipoContatos_TipoContatoId",
                table: "tbContato",
                column: "TipoContatoId",
                principalTable: "TipoContatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
