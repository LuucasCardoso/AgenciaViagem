using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("ReservasHotel")]
    public class ReservaHotel
    {
        [Key]
        public int ReservaHotelId { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public DateTime DataReserva { get; set; }

        //Propriedades Usuario
        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario _Usuario { get; set; }

        //Propriedades Hotel
        [Required]
        public int HotelId { get; set; }
        public virtual Hotel _Hotel { get; set; }
    }
}
