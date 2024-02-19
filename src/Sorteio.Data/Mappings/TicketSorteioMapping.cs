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
    public class TicketSorteioMapping : IEntityTypeConfiguration<TicketSorteio>
    {
        public void Configure(EntityTypeBuilder<TicketSorteio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                    .IsRequired()
                    .HasColumnType("integer");

            builder.Property(p => p.DataCadastro)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.DataAlteracao)
                   .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.HasMany(p => p.HistoricoSorteios)
                   .WithOne(p => p.TicketSorteio)
                   .HasForeignKey(p => p.IdTicketSorteio);

            builder.ToTable("TicketSorteio");
        }
    }
}
