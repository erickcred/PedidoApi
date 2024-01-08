using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PedidoProduto1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
