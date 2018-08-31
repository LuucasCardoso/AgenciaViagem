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
            var lista = from u in db.Usuarios
                        where u.Nome == "Admin"
                        select u;
            if (!lista.Any())
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
            lista = from u in db.Usuarios
                    where u.Nome == "Teste"
                    select u;
            if (!lista.Any())
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
            db.SaveChanges();
            Console.WriteLine("Banco Populado!!");
            Console.ReadKey();
        }
    }
}
