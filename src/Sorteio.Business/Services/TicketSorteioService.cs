using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Interfaces.Services;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Models.Validations;
using Sorteio.Business.Models;
using Sorteio.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Services
{
    public class TicketSorteioService : BaseService<TicketSorteio>, ITicketSorteioService
    {

        private readonly ITicketSorteioRepository _ticketSorteioRepository;
        private readonly IHistoricoSorteioRepository _historicoSorteioRepository;
        private readonly IParticipanteSorteioRepository _participanteRepo;
        private readonly IDadosSorteioRepository _dadoRepo;

        private Random _random;
        public TicketSorteioService(ITicketSorteioRepository ticketSorteioRepository,
                                    IHistoricoSorteioRepository historicoSorteioRepository,
                                    IParticipanteSorteioRepository participanteRepo,
                                    IDadosSorteioRepository dadoRepo,
                                    INotificador notificador) : base(ticketSorteioRepository, notificador)
        {
            _ticketSorteioRepository = ticketSorteioRepository;
            _historicoSorteioRepository = historicoSorteioRepository;
            _participanteRepo = participanteRepo;
            _dadoRepo=dadoRepo;
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public TicketSorteio Sortear(Guid idDadosSorteio)
        {

            var historicoSorteio = _historicoSorteioRepository
                                            .BuscarComTicketSorteio()
                                            .FirstOrDefault(x => x.TicketSorteio.IdDadosSorteio == idDadosSorteio);

            if (historicoSorteio == null)
            {

                var tickets = _ticketSorteioRepository.Obter(x => x.IdDadosSorteio == idDadosSorteio).Result;

                var numberMax = tickets.Select(x => x.Numero).Max();

                var contemplado = _random.Next(1, numberMax + 1);

                var sorteado = tickets.FirstOrDefault(x => x.Numero == contemplado);

                if (sorteado == null)
                {
                    Notificar("Não foi possível encontrar o número sorteado");
                    return new TicketSorteio();
                }
                else
                {
                    _historicoSorteioRepository.Adicionar(new HistoricoSorteio { IdTicketSorteio = sorteado.Id, Descricao = $"Sorteio realizado na data {DateTime.Now.ToShortTimeString()} com premiado de numero: {sorteado.Numero}" });
                }
                return sorteado;

            }
            else
            {
                Notificar("Este sorteio já aconteceu!");
                return historicoSorteio.TicketSorteio;
            }


            

        }

        public override Task Atualizar<TV>(TicketSorteio entidade, TV validator)
        {

            var ticketAntigo = _ticketSorteioRepository.ObterPorId(entidade.Id).Result;

            var ticketSorteioUpdate = new TicketSorteio
            {
                Id = entidade.Id,
                IdDadosSorteio = entidade.IdDadosSorteio,
                IdParticipanteSorteio = entidade.IdParticipanteSorteio,
                Numero=entidade.Numero,
                Ativo = true,
                DataCadastro= ticketAntigo.DataCadastro,
                DataAlteracao = DateTime.Now
            };

            return base.Atualizar(ticketSorteioUpdate, validator);
        }
    }
}

