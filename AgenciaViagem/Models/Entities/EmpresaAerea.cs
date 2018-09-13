﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("EmpresasAereas")]
    public class EmpresaAerea
    {
        public int EmpresaAereaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //Propriedades Passagens
        public virtual ICollection<Passagem> _Passagens { get; set; }
    }
}
