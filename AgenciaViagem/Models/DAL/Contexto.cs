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
        public DbSet<EmpresaAerea> EmpresasAereas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<QuartoTipo> QuartoTipos { get; set; }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
    }
}
