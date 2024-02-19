using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Mappings
{
    public class ParticipanteSorteioMapping : IEntityTypeConfiguration<ParticipanteSorteio>
    {
        public void Configure(EntityTypeBuilder<ParticipanteSorteio> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Endereco)
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Estado)
                   .HasColumnType("varchar(2)");

            builder.Property(p => p.Cidade)
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");


            builder.Property(p => p.Telefone)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(p => p.CPF)
                   .IsRequired()
                   .HasColumnType("varchar(50)");


            builder.Property(p => p.DataCadastro)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.DataAlteracao)
                   .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.HasMany(p => p.TicketSorteios)
                  .WithOne(p => p.ParticipanteSorteio)
                  .HasForeignKey(p => p.IdParticipanteSorteio);


            builder.ToTable("ParticipanteSorteio");
        }
    }
}
