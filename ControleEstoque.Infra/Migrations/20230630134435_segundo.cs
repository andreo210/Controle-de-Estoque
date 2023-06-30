using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_entrada_produto_EntradaId",
                table: "produto");

            migrationBuilder.DropIndex(
                name: "IX_produto_EntradaId",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "EntradaId",
                table: "produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntradaId",
                table: "produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_produto_EntradaId",
                table: "produto",
                column: "EntradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_entrada_produto_EntradaId",
                table: "produto",
                column: "EntradaId",
                principalTable: "entrada_produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
