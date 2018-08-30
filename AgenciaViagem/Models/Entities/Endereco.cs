using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        public int CidadeId { get; set; }
        public virtual Cidade _Cidade { get; set; }
    }
}
