using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Quartos")]
    public class Quarto
    {
        public int QuartoId { get; set; }
        public string Numero { get; set; }
        public bool Ativo { get; set; }

        //Propriedades Quarto Tipo
        public int QuartoTipoId { get; set; }
        public virtual QuartoTipo _QuartoTipo { get; set; }

        //Propriedades Hotel
        public int HotelId { get; set; }
        public virtual Hotel _Hotel { get; set; }

        //Propriedades Pacotes
        public virtual ICollection<Pacote> _Pacotes { get; set; }
    }
}
