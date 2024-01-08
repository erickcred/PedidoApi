using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PedidoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Produto",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroPedido = table.Column<string>(type: "Varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateEmissao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataChegada = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PrevisaoEntrega = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ClienteId = table.Column<int>(type: "Int", nullable: false),
                    Finalizado = table.Column<sbyte>(type: "Tinyint", nullable: false, defaultValue: (sbyte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produto");
        }
    }
}
