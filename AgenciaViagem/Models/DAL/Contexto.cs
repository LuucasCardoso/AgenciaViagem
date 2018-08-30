using Models.Entities;
using Models.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(): base("AgenciaViagemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
