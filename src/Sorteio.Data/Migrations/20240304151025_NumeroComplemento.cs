using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorteio.Data.Migrations
{
    /// <inheritdoc />
    public partial class NumeroComplemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "ParticipanteSorteio",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "ParticipanteSorteio",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "ParticipanteSorteio");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "ParticipanteSorteio");
        }
    }
}
