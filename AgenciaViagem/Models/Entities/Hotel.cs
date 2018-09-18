﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Hoteis")]
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }

        //Propriedades Quartos
        public virtual ICollection<Quarto> Quartos { get; set; }

        //Propriedades Cidade
        public int CidadeId { get; set; }
        public virtual Cidade _Cidade { get; set; }
    }
}
