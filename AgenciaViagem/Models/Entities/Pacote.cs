using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Pacotes")]
    public class Pacote
    {
        [Key]
        public int PacoteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }

        //Propriedades Hotel
        [Required]
        public int HotelId { get; set; }
        public virtual Hotel _Hotel { get; set; }

        //Propriedades Passagem
        [Required]
        public int PassagemId { get; set; }
        public virtual Passagem _Passagem { get; set; }
    }
}
