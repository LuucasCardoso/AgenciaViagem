using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Estados")]
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        //Propriedades Cidades
        public virtual ICollection<Cidade> _Cidades { get; set; }

        //Propriedades País
        public int PaisId { get; set; }
        public virtual Pais _Pais { get; set; }
    }
}
