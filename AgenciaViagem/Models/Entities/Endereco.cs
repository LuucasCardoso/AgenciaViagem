using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Enderecos")]
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        //Propriedades Cidade
        //public int CidadeId { get; set; }
        //public virtual Cidade _Cidade { get; set; }

        //Propriedades Hotéis
        public virtual ICollection<Hotel> Hoteis { get; set; }
    }
}
