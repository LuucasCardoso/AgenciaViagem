using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{

    [Table("Carrinho")]
    public class Carrinho
    {
        public int CarrinhoId { get; set; }

        //Propriedades ItemCompra
        public virtual ItemCompra _ItemCompra { get; set; }

    }
}
