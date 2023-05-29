using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoque.Infra.Migrations
{
    public partial class terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbContato_TipoContatoId",
                table: "tbContato");

            migrationBuilder.CreateIndex(
                name: "IX_tbContato_TipoContatoId",
                table: "tbContato",
                column: "TipoContatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbContato_TipoContatoId",
                table: "tbContato");

            migrationBuilder.CreateIndex(
                name: "IX_tbContato_TipoContatoId",
                table: "tbContato",
                column: "TipoContatoId",
                unique: true);
        }
    }
}
