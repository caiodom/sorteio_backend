using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Mappings
{
    public class HistoricoSorteioMapping : IEntityTypeConfiguration<HistoricoSorteio>
    {
        public void Configure(EntityTypeBuilder<HistoricoSorteio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                    .HasColumnType("varchar(1000)");

            builder.Property(p => p.DataCadastro)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.DataAlteracao)
                   .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.ToTable("HistoricoSorteio");
        }
    }
    
    
}
