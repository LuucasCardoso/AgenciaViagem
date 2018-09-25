using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("ReservasPacote")]
    public class ReservaPacote
    {
        [Key]
        public int ReservaPacoteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public float Preco { get; set; }

    }
}
