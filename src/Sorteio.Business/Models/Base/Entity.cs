using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Models.Base
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id=Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

    }
}
