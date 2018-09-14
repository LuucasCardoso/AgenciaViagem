using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Paises")]
    public class Pais
    {
        public int PaisId { get; set; }
        public string Nome { get; set; }

        //Propriedades Estados
        public virtual ICollection<Estado> _Estados { get; set; }
    }
}
