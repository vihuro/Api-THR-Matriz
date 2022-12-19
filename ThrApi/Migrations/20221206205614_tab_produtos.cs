using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrApi.Migrations
{
    public partial class tab_produtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimName = table.Column<string>(type: "text", nullable: false),
                    ClaimValue = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Unidade = table.Column<string>(type: "text", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    CategoriaA = table.Column<string>(type: "text", nullable: false),
                    CategoriaB = table.Column<string>(type: "text", nullable: true),
                    CategoriaC = table.Column<string>(type: "text", nullable: true),
                    QuantidadeEstoque = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueSeguranca = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueMinimo = table.Column<decimal>(type: "numeric", nullable: false),
                    EstoqueMaximo = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCadastro = table.Column<string>(type: "text", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeUsuario = table.Column<string>(type: "text", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "tab_Produtos");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
