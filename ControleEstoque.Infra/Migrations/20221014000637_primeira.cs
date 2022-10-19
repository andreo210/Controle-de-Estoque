using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.id);
                });

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
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    id_pais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.id);
                    table.ForeignKey(
                        name: "FK_estado_pais_id_pais",
                        column: x => x.id_pais,
                        principalTable: "pais",
                        principalColumn: "id",
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
                        name: "FK_perfil_usuario_usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cidade_estado_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    razao_social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    num_documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    id_pais = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    id_cidade = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fornecedor_Cidade_id_cidade",
                        column: x => x.id_cidade,
                        principalTable: "Cidade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_fornecedor_estado_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estado",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_fornecedor_pais_id_pais",
                        column: x => x.id_pais,
                        principalTable: "pais",
                        principalColumn: "id");
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
                        name: "FK_produto_fornecedor_id_fornecedor",
                        column: x => x.id_fornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_produto_tb_MarcasProdutos_id_grupo",
                        column: x => x.id_grupo,
                        principalTable: "tb_MarcasProdutos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_tb_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "tb_unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_id_estado",
                table: "Cidade",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_entrada_produto_id_produto",
                table: "entrada_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_estado_id_pais",
                table: "estado",
                column: "id_pais");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_id_cidade",
                table: "fornecedor",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_id_estado",
                table: "fornecedor",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_id_pais",
                table: "fornecedor",
                column: "id_pais");

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
                name: "IX_produto_id_unidade_medida",
                table: "produto",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_saida_produto_id_produto",
                table: "saida_produto",
                column: "id_produto");
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
                name: "perfil");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "fornecedor");

            migrationBuilder.DropTable(
                name: "tb_grupoProduto");

            migrationBuilder.DropTable(
                name: "tb_locaisArmazenamento");

            migrationBuilder.DropTable(
                name: "tb_MarcasProdutos");

            migrationBuilder.DropTable(
                name: "tb_unidade_medida");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
