using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Passagens")]
    public class Passagem
    {
        public int PassagemId { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataEmbarque { get; set; }
        public DateTime DataVolta { get; set; }
        public enum Classe
        {
            VIP,
            Convencional,
            Executiva,
            Master
        }

        //Propriedades Cidade
        [ForeignKey("_CidadeOrigem")]
        public int CidadeOrigemId { get; set; }
        [ForeignKey("_CidadeDestino")]
        public int CidadeDestinoId { get; set; }
        public virtual Cidade _CidadeOrigem { get; set; }
        public virtual Cidade _CidadeDestino { get; set; }

        //Propriedades Empresas Aéreas
        public int EmpresaAereaId { get; set; }
        public virtual EmpresaAerea _EmpresaAerea { get; set; }

        //Propriedades Pacotes
        public virtual ICollection<Pacote> _Pacotes { get; set; }
    }
}
