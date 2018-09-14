using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Hoteis")]
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //Propriedades Quartos
        public virtual ICollection<Quarto> Quartos { get; set; }

        //Propriedades Endereço
        public int EnderecoId { get; set; }
        public virtual Endereco _Endereco { get; set; }
    }
}
