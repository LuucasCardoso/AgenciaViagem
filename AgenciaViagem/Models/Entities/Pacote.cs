using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Pacotes")]
    public class Pacote
    {
        public int PacoteId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        //Propriedades Quarto
        public int QuartoId { get; set; }
        public virtual Quarto _Quarto { get; set; }

        //Propriedades Passagem
        public int PassagemId { get; set; }
        public virtual Passagem _Passagem { get; set; }
    }
}
