using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        [Required]
        public string Nome { get; set; }

        //Propriedades Cidades
        public virtual ICollection<Cidade> _Cidades { get; set; }

        //Propriedades País
        [Required]
        public int PaisId { get; set; }
        public virtual Pais _Pais { get; set; }
    }
}
