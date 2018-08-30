using Modelos.Migrations;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
