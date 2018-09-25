﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Passagens")]
    public class Passagem
    {
        [Key]
        public int PassagemId { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataEmbarque { get; set; }
        public DateTime DataVolta { get; set; }
        public string CidadeOrigem { get; set; }
        public string CidadeDestino { get; set; }

        //Propriedades Cidade
        //public int CidadeOrigemId { get; set; }
        //public virtual Cidade _CidadeOrigem { get; set; }

        //public int CidadeDestinoId { get; set; }
        //public virtual Cidade _CidadeDestino { get; set; }

        //Propriedades Empresas Aéreas
        public int EmpresaAereaId { get; set; }
        public virtual EmpresaAerea _EmpresaAerea { get; set; }

        //Propriedades Usuario
        public int UsuarioId { get; set; }
        public virtual Usuario _Usuario { get; set; }

        //Propriedades Pacotes
        public virtual ICollection<Pacote> _Pacotes { get; set; }

    }
}
