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

            // Usuario
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

            // Pais
            var pais = from p in db.Paises
                       where p.Nome == "Itália"
                       select p;
            if (!pais.Any())
            {
                db.Paises.Add(new Pais()
                {
                    Nome = "Itália"
                });
                Console.WriteLine("País 'Itália' criado!");
            }
            else
            {
                Console.WriteLine("País 'Itália' já existe!");
            }
            pais = from p in db.Paises
                   where p.Nome == "Brasil"
                   select p;
            if (!pais.Any())
            {
                db.Paises.Add(new Pais()
                {
                    Nome = "Brasil"
                });
                Console.WriteLine("País 'Brasil' criado!");
            }
            else
            {
                Console.WriteLine("País 'Brasil' já existe!");
            }
            pais = from p in db.Paises
                   where p.Nome == "Jamaica"
                   select p;
            if (!pais.Any())
            {
                db.Paises.Add(new Pais()
                {
                    Nome = "Jamaica"
                });
                Console.WriteLine("País 'Jamaica' criado!");
            }
            else
            {
                Console.WriteLine("País 'Jamaica' já existe!");
            }
            db.SaveChanges();
            // Estado
            var estado = from e in db.Estados
                       where e.Nome == "Piemonte"
                       select e;
            if (!estado.Any())
            {
                db.Estados.Add(new Estado()
                {
                    Nome = "Piemonte",
                    PaisId = 1
                });
                Console.WriteLine("Estado 'Piemonte' criado!");
                db.Estados.Add(new Estado()
                {
                    Nome = "Vale de Aosta",
                    PaisId = 1
                });
                Console.WriteLine("Estado 'Vale de Aosta' criado!");
            }
            else
            {
                Console.WriteLine("Estados 'Piemonte' e 'Vale de Aosta' já existem!");
            }
            //+
            estado = from e in db.Estados
                     where e.Nome == "São Paulo"
                     select e;
            if (!estado.Any())
            {
                db.Estados.Add(new Estado()
                {
                    Nome = "São Paulo",
                    PaisId = 2
                });
                Console.WriteLine("Estado 'São Paulo' criado!");
                db.Estados.Add(new Estado()
                {
                    Nome = "Rio de Janeiro",
                    PaisId = 2
                });
                Console.WriteLine("Estado 'Rio de Janeiro' criado!");
            }
            else
            {
                Console.WriteLine("Estados 'São Paulo' e 'Rio de Janeiro' já existem!");
            }
            //+
            estado = from e in db.Estados
                     where e.Nome == "Kingston"
                     select e;
            if (!estado.Any())
            {
                db.Estados.Add(new Estado()
                {
                    Nome = "Kingston",
                    PaisId = 3
                });
                Console.WriteLine("Estado 'Kingston' criado!");
                db.Estados.Add(new Estado()
                {
                    Nome = "Clarendon",
                    PaisId = 3
                });
                Console.WriteLine("Estado 'Clarendon' criado!");
            }
            else
            {
                Console.WriteLine("Estados 'Kingston' e 'Clarendon' já existem!");
            }
            db.SaveChanges();
            //Cidade
            var cidade = from c in db.Cidades
                         where c.Nome == "Turim"
                         select c;
            if (!cidade.Any())
            {
                db.Cidades.Add(new Cidade()
                {
                    Nome = "Turim",
                    EstadoId = 1
                });
                Console.WriteLine("Cidade 'Turim' criada!");
                db.Cidades.Add(new Cidade()
                {
                    Nome = "Aosta",
                    EstadoId = 2
                });
                Console.WriteLine("Cidade 'Aosta' criada!");
            }
            else
            {
                Console.WriteLine("Cidades 'Turim' e 'Aosta' já existem!");
            }
            //+
            cidade = from c in db.Cidades
                     where c.Nome == "São Paulo"
                     select c;
            if (!cidade.Any())
            {
                db.Cidades.Add(new Cidade()
                {
                    Nome = "São Paulo",
                    EstadoId = 3
                });
                Console.WriteLine("Cidade 'São Paulo' criada!");
                db.Cidades.Add(new Cidade()
                {
                    Nome = "Rio de Janeiro",
                    EstadoId = 4
                });
                Console.WriteLine("Cidade 'Rio de Janeiro' criada!");
            }
            else
            {
                Console.WriteLine("Cidades 'São Paulo' e 'Rio de Janeiro' já existem!");
            }
            //+
            cidade = from c in db.Cidades
                     where c.Nome == "Kingston"
                     select c;
            if (!cidade.Any())
            {
                db.Cidades.Add(new Cidade()
                {
                    Nome = "Kingston",
                    EstadoId = 5
                });
                Console.WriteLine("Cidade 'Kingston' criada!");
                db.Cidades.Add(new Cidade()
                {
                    Nome = "May Pen",
                    EstadoId = 6
                });
                Console.WriteLine("Cidade 'May Pen' criada!");
            }
            else
            {
                Console.WriteLine("Cidades 'Kingston' e 'May Pen' já existem!");
            }

            db.SaveChanges();
            Console.WriteLine("Banco Populado!!");
            Console.ReadKey();
        }
    }
}
