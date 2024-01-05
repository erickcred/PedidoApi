using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddNomeContatoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeContato",
                table: "Cliente",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeContato",
                table: "Cliente");
        }
    }
}
