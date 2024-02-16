using Sorteio.Business.Interfaces.Base;
using Sorteio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Interfaces.Services
{
    public interface IParticipanteSorteioService : IService<ParticipanteSorteio>
    {

        Task Adicionar(ParticipanteSorteio participanteSorteio);
        Task Atualizar(ParticipanteSorteio participanteSorteio);
        Task Remover(Guid id);

    }
}
