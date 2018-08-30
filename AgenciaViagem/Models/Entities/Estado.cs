using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> _Cidades { get; set; }
        public int PaisId { get; set; }
        public virtual Pais _Pais { get; set; }
    }
}
