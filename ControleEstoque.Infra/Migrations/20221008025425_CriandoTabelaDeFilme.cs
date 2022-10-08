using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class CriandoTabelaDeFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(3)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    id_pais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estado_pais_id_pais",
                        column: x => x.id_pais,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_estado_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_id_estado",
                table: "Cidade",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_estado_id_pais",
                table: "estado",
                column: "id_pais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
