using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorteio.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosSorteio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Premio = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValorPremio = table.Column<decimal>(type: "decimal(20,4)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosSorteio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteSorteio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteSorteio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketSorteio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdParticipanteSorteio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDadosSorteio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSorteio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSorteio_DadosSorteio_IdDadosSorteio",
                        column: x => x.IdDadosSorteio,
                        principalTable: "DadosSorteio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketSorteio_ParticipanteSorteio_IdParticipanteSorteio",
                        column: x => x.IdParticipanteSorteio,
                        principalTable: "ParticipanteSorteio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSorteio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTicketSorteio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSorteio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoSorteio_TicketSorteio_IdTicketSorteio",
                        column: x => x.IdTicketSorteio,
                        principalTable: "TicketSorteio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSorteio_IdTicketSorteio",
                table: "HistoricoSorteio",
                column: "IdTicketSorteio");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSorteio_IdDadosSorteio",
                table: "TicketSorteio",
                column: "IdDadosSorteio");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSorteio_IdParticipanteSorteio",
                table: "TicketSorteio",
                column: "IdParticipanteSorteio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoSorteio");

            migrationBuilder.DropTable(
                name: "TicketSorteio");

            migrationBuilder.DropTable(
                name: "DadosSorteio");

            migrationBuilder.DropTable(
                name: "ParticipanteSorteio");
        }
    }
}
