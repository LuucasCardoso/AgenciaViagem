using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        [Required]
        public string Nome { get; set; }

        //Propriedades Enderecos
        //public virtual ICollection<Endereco> _Enderecos { get; set; }

        //Propriedades Estado
        [Required]
        public int EstadoId { get; set; }
        public virtual Estado _Estado { get; set; }

        //Propriedades Passagens
        public virtual ICollection<Passagem> _Passagens { get; set; }

        //Propriedades Hoteis
        public virtual ICollection<Hotel> _Hoteis { get; set; }

    }
}
