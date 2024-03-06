using Microsoft.EntityFrameworkCore;
using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Models;
using Sorteio.Business.Models.Base;
using Sorteio.Data.Context;
using Sorteio.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Repository
{
    public class TicketSorteioRepository : Repository<TicketSorteio>, ITicketSorteioRepository
    {
        public TicketSorteioRepository(SorteioDbContext db) : base(db)
        {
        }

        public IEnumerable<TicketSorteio> ListarTicketsCompletos()
        {

            return TicketsCompletosQueryable()
                        .Select(x => new TicketSorteio
                        {
                            Id = x.Id,
                            Ativo = x.Ativo,
                            DataAlteracao = x.DataAlteracao,
                            DataCadastro = x.DataCadastro,
                            IdDadosSorteio = x.IdDadosSorteio,
                            IdParticipanteSorteio = x.IdParticipanteSorteio,
                            Numero = x.Numero,
                            DadosSorteio = new DadosSorteio { Descricao = x.DadosSorteio.Descricao },
                            ParticipanteSorteio = new ParticipanteSorteio { Nome = x.ParticipanteSorteio.Nome }
                        });
        }

        public IEnumerable<TicketSorteio> ListarTicketsCompletos(Expression<Func<TicketSorteio, bool>> predicate)
        {
            return TicketsCompletosQueryable()
                        .Where(predicate)
                        .Select(x => new TicketSorteio
                        {
                            Id = x.Id,
                            Ativo = x.Ativo,
                            DataAlteracao = x.DataAlteracao,
                            DataCadastro = x.DataCadastro,
                            IdDadosSorteio = x.IdDadosSorteio,
                            IdParticipanteSorteio = x.IdParticipanteSorteio,
                            Numero = x.Numero,
                            DadosSorteio = new DadosSorteio { Descricao = x.DadosSorteio.Descricao },
                            ParticipanteSorteio = new ParticipanteSorteio { Nome = x.ParticipanteSorteio.Nome }
                        });
        }


        private IQueryable<TicketSorteio> TicketsCompletosQueryable()
        => DbSet.Include(x => x.DadosSorteio)
                .Include(x => x.ParticipanteSorteio);
    }
}
