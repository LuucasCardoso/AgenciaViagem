using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Endereco> _Enderecos { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado _Estado { get; set; }
    }
}
