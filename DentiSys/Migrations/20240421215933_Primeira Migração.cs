using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentiSys.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigração : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacienteProcedimentos",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdProcedimento = table.Column<int>(type: "int", nullable: false),
                    DataProcedimento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    ProcedimentoRealizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteProcedimentos", x => new { x.IdPaciente, x.IdProcedimento });
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDePlano = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coberturas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Idade = table.Column<int>(type: "INT", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true, defaultValue: "00000000000"),
                    DataDeAniversario = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumeroDeTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Especialização = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDeRegistro = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    IdEndereco = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dentistas_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SobreNome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Idade = table.Column<int>(type: "INT", nullable: true, defaultValue: 18),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true, defaultValue: "00000000000"),
                    DataDeAniversario = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumeroDeTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientePlanos",
                columns: table => new
                {
                    IdPlano = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    PlanoId = table.Column<int>(type: "int", nullable: false),
                    PlanoAtivo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientePlanos", x => new { x.IdPlano, x.IdPaciente });
                    table.ForeignKey(
                        name: "FK_PacientePlanos_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_IdEndereco",
                table: "Dentistas",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CEP",
                table: "Endereco",
                column: "CEP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacientePlanos_PlanoId",
                table: "PacientePlanos",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteProcedimento_ProcedimentoRealizado",
                table: "PacienteProcedimentos",
                column: "ProcedimentoRealizado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdEndereco",
                table: "Pacientes",
                column: "IdEndereco",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dentistas");

            migrationBuilder.DropTable(
                name: "PacientePlanos");

            migrationBuilder.DropTable(
                name: "PacienteProcedimentos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
