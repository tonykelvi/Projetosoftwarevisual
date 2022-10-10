using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAdmin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    idCarro = table.Column<int>(type: "INTEGER", nullable: false),
                    modelo = table.Column<string>(type: "TEXT", nullable: true),
                    placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    contato = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    idCarro = table.Column<int>(type: "INTEGER", nullable: false),
                    idVendedor = table.Column<int>(type: "INTEGER", nullable: false),
                    dataempr = table.Column<string>(type: "TEXT", nullable: true),
                    datadev = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    idVendedor = table.Column<int>(type: "INTEGER", nullable: false),
                    nomeFuncionario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
