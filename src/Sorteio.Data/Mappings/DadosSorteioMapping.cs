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
    public class DadosSorteioMapping : IEntityTypeConfiguration<DadosSorteio>
    {
        public void Configure(EntityTypeBuilder<DadosSorteio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                    .HasColumnType("varchar(1000)");

            builder.Property(p => p.Premio)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.ValorPremio)
                   .IsRequired()
                   .HasColumnType("decimal(20,4)");

            builder.Property(p=>p.DataCadastro)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.DataAlteracao)
                   .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.HasMany(p => p.TicketSorteios)
                   .WithOne(p => p.DadosSorteio)
                   .HasForeignKey(p => p.IdDadosSorteio);

            builder.ToTable("DadosSorteio");
        }
    }
}
