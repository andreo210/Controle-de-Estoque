using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_grupoProduto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grupoProduto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_locaisArmazenamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_locaisArmazenamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_MarcasProdutos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_MarcasProdutos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_unidade_medida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sigla = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_unidade_medida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoContato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Razao_social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Num_documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TipoFornecedorId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbFornecedor_tbTipoFornecedor_TipoFornecedorId",
                        column: x => x.TipoFornecedorId,
                        principalTable: "tbTipoFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil_usuario",
                columns: table => new
                {
                    PerfisId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_usuario", x => new { x.PerfisId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_perfil_usuario_perfil_PerfisId",
                        column: x => x.PerfisId,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfil_usuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco_custo = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    preco_venda = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    quant_estoque = table.Column<int>(type: "int", nullable: false),
                    id_unidade_medida = table.Column<int>(type: "int", nullable: false),
                    id_grupo = table.Column<int>(type: "int", nullable: false),
                    id_marca = table.Column<int>(type: "int", nullable: false),
                    id_fornecedor = table.Column<int>(type: "int", nullable: false),
                    id_local_aramazenamento = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    imagem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_produto_tb_grupoProduto_id_grupo",
                        column: x => x.id_grupo,
                        principalTable: "tb_grupoProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_tb_locaisArmazenamento_id_local_aramazenamento",
                        column: x => x.id_local_aramazenamento,
                        principalTable: "tb_locaisArmazenamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_tb_MarcasProdutos_id_marca",
                        column: x => x.id_marca,
                        principalTable: "tb_MarcasProdutos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_tb_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "tb_unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_tbFornecedor_id_fornecedor",
                        column: x => x.id_fornecedor,
                        principalTable: "tbFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    TipoContatoId = table.Column<int>(type: "int", nullable: false),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbContato_tbFornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "tbFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbContato_tbTipoContato_TipoContatoId",
                        column: x => x.TipoContatoId,
                        principalTable: "tbTipoContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdFornecedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbEndereco_tbFornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "tbFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entrada_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quant = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrada_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_entrada_produto_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventario_estoque",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    quant_estoque = table.Column<int>(type: "int", nullable: false),
                    quant_inventario = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_estoque", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventario_estoque_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "saida_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quant = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saida_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_saida_produto_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbTipoContato",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Celular" },
                    { 2, null }
                });

            migrationBuilder.InsertData(
                table: "tbTipoFornecedor",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Fisica" },
                    { 2, "Juridica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_entrada_produto_id_produto",
                table: "entrada_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_estoque_id_produto",
                table: "inventario_estoque",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_usuario_UsuariosId",
                table: "perfil_usuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_fornecedor",
                table: "produto",
                column: "id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_grupo",
                table: "produto",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_local_aramazenamento",
                table: "produto",
                column: "id_local_aramazenamento");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_marca",
                table: "produto",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_unidade_medida",
                table: "produto",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_saida_produto_id_produto",
                table: "saida_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_tbContato_IdFornecedor",
                table: "tbContato",
                column: "IdFornecedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbContato_TipoContatoId",
                table: "tbContato",
                column: "TipoContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbEndereco_IdFornecedor",
                table: "tbEndereco",
                column: "IdFornecedor",
                unique: true,
                filter: "[IdFornecedor] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbFornecedor_TipoFornecedorId",
                table: "tbFornecedor",
                column: "TipoFornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entrada_produto");

            migrationBuilder.DropTable(
                name: "inventario_estoque");

            migrationBuilder.DropTable(
                name: "perfil_usuario");

            migrationBuilder.DropTable(
                name: "saida_produto");

            migrationBuilder.DropTable(
                name: "tbContato");

            migrationBuilder.DropTable(
                name: "tbEndereco");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "tbTipoContato");

            migrationBuilder.DropTable(
                name: "tb_grupoProduto");

            migrationBuilder.DropTable(
                name: "tb_locaisArmazenamento");

            migrationBuilder.DropTable(
                name: "tb_MarcasProdutos");

            migrationBuilder.DropTable(
                name: "tb_unidade_medida");

            migrationBuilder.DropTable(
                name: "tbFornecedor");

            migrationBuilder.DropTable(
                name: "tbTipoFornecedor");
        }
    }
}
