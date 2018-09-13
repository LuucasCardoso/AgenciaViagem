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
        public int QuantidadeQuartos { get; set; }
        public enum OpcionaisQuarto {
            CamaCasal,
            Hidromassagem,
            ServicoQuarto
        }

        //Propriedades Quartos
        public virtual ICollection<Quarto> _Quartos { get; set; }
    }
}
