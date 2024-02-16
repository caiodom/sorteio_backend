﻿using Sorteio.Business.Interfaces.Repository;
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
        public TicketSorteioService(ITicketSorteioRepository ticketSorteioRepository, INotificador notificador) : base(ticketSorteioRepository, notificador)
        {
        }
    }
}

