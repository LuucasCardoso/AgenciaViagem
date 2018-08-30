using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    class Pais
    {
        public int PaisId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Estado> _Estados { get; set; }
    }
}
