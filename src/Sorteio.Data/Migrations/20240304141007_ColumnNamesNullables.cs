﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorteio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNamesNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "ParticipanteSorteio",
                newName: "Logradouro");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "ParticipanteSorteio",
                type: "varchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "ParticipanteSorteio");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "ParticipanteSorteio",
                newName: "Endereco");
        }
    }
}
