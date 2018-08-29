using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.DAL
{
    class Contexto : DbContext
    {
        public Contexto(): base("AgenciaViagemDB")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
