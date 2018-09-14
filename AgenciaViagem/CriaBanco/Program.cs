using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriaBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Populando Banco...");
            var db = new Contexto();
            var usuario = from u in db.Usuarios
                        where u.Nome == "Admin"
                        select u;
            if (!usuario.Any())
            {
                db.Usuarios.Add(new Usuario()
                {
                    User = "admin",
                    Password = "admin",
                    Administrador = true,
                    Nome = "Admin",
                    Email = "admin@admin.com",
                    Ativo = true,
                    Cpf = "12345678910",
                    Telefone = "5541999999999"
                });
                Console.WriteLine("Criada entidade Administrativa! User: admin Senha: admin");
            }
            else
            {
                Console.WriteLine("Entidade Administrativa já existe!");
            }
            usuario = from u in db.Usuarios
                    where u.Nome == "Teste"
                    select u;
            if (!usuario.Any())
            {
                db.Usuarios.Add(new Usuario()
                {
                    User = "teste",
                    Password = "teste",
                    Administrador = false,
                    Nome = "Teste",
                    Email = "teste@teste.com",
                    Ativo = true,
                    Cpf = "10123456789",
                    Telefone = "5541888888888"
                });
                Console.WriteLine("Criada entidade Teste! User: teste Senha: teste");
            }
            else
            {
                Console.WriteLine("Entidade Teste já existe!");
            }
            var QuartoTipo = from qt in db.QuartoTipos
                                   where qt.Nome == "Básico"
                                   select qt;
            if (!QuartoTipo.Any())
            {
                db.QuartoTipos.Add(new QuartoTipo()
                {
                    Nome = "Básico",
                    QuantidadeQuartos = 1,
                    CamaCasal = false,
                    Hidromassagem = false,
                    ServicoQuarto = false
                });
                Console.WriteLine("Tipo de vaga 'Básico' criada!");
            }
            else
            {
                Console.WriteLine("Tipo de vaga 'Básico' já existe!");
            }
            QuartoTipo = from qt in db.QuartoTipos
                             where qt.Nome == "Intermediário"
                             select qt;
            if (!QuartoTipo.Any())
            {
                db.QuartoTipos.Add(new QuartoTipo()
                {
                    Nome = "Intermediário",
                    QuantidadeQuartos = 2,
                    CamaCasal = true,
                    Hidromassagem = false,
                    ServicoQuarto = true
                });
                Console.WriteLine("Tipo de vaga 'Intermediário' criada!");
            }
            else
            {
                Console.WriteLine("Tipo de vaga 'Intermediário' já existe!");
            }
            QuartoTipo = from qt in db.QuartoTipos
                             where qt.Nome == "Patrão"
                             select qt;
            if (!QuartoTipo.Any())
            {
                db.QuartoTipos.Add(new QuartoTipo()
                {
                    Nome = "Patrão",
                    QuantidadeQuartos = 3,
                    CamaCasal = true,
                    Hidromassagem = true,
                    ServicoQuarto = true
                });
                Console.WriteLine("Tipo de vaga 'Patrão' criada!");
            }
            else
            {
                Console.WriteLine("Tipo de vaga 'Patrão' já existe!");
            }
            db.SaveChanges();
            Console.WriteLine("Banco Populado!!");
            Console.ReadKey();
        }
    }
}
