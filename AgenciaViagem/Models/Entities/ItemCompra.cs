using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{

        [Table("ItensCompra")]

        public class ItemCompra
        {
            public int ItemCompraId { get; set; }
            public double Preco { get; set; }

            //Propriedades Passagens
            public virtual Passagem _Passagem { get; set; }
            
            //Propriedades Hoteis
            public virtual Hotel _Hotel { get; set; }

            //Propriedades Pacotes
            public virtual Pacote _Pacote { get; set; }
            
        }

}
