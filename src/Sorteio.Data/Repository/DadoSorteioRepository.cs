﻿using Sorteio.Business.Interfaces.Repository;
using Sorteio.Business.Models;
using Sorteio.Data.Context;
using Sorteio.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Data.Repository
{
    public class DadoSorteioRepository : Repository<DadoSorteio>,IDadoSorteioRepository
    {
        public DadoSorteioRepository(SorteioDbContext db) : base(db)
        {
        }
    }
}
