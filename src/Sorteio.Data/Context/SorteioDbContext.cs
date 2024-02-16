using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Context
{
    public class SorteioDbContext:DbContext
    {
        public SorteioDbContext(DbContextOptions<SorteioDbContext> options) : base(options)
        {
             //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
             //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<TicketSorteio> TicketSorteios { get; set; }
        public DbSet<HistoricoSorteio> HistoricoSorteios { get; set; }
        public DbSet<ParticipanteSorteio> ParticipanteSorteios { get; set; }
        public DbSet<DadosSorteio> DadoSorteios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SorteioDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries= ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null &&
                                                                entry.Entity.GetType().GetProperty("DataAlteracao")!=null &&
                                                                entry.Entity.GetType().GetProperty("Ativo")!=null);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                

                if(entry.State== EntityState.Modified)
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                 
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
