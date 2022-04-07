using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Funcionario_API.Data.Migrations
{
    public partial class createtablefuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    documento = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    setor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    salario_bruto = table.Column<decimal>(type: "numeric", nullable: false),
                    admissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    plano_saude = table.Column<bool>(type: "boolean", nullable: false),
                    plano_dentral = table.Column<bool>(type: "boolean", nullable: false),
                    vale_transporte = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
