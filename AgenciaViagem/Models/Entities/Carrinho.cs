using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{

    public class Carrinho
    {
        //Propriedades ReservaHotel
        public List<ReservaHotel> reservasHotel { get; set; }

    }
}
