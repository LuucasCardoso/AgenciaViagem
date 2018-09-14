using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("QuartoTipos")]
    public class QuartoTipo 
    {
        public int QuartoTipoId { get; set; }
        public string Nome { get; set; }
        public int QuantidadeQuartos { get; set; }
        public bool CamaCasal { get; set; }
        public bool Hidromassagem { get; set; }
        public bool ServicoQuarto { get; set; }

        //Propriedades Quartos
        public virtual ICollection<Quarto> _Quartos { get; set; }
    }
}
