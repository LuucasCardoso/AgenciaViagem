using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class UsuarioDAO
    {
        static readonly Contexto db = new Contexto();

        public void Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
        public Usuario ReadByUsername(string user)
        {
            var usuariodb = from u in db.Usuarios
                        where u.User == user
                        select u;
            return usuariodb.FirstOrDefault();
        }
        public IList<Usuario> List()
        {
            using(var db = new Contexto()){
                return db.Usuarios.ToList();
            }
        }
        public void Update(Usuario usuario)
        {
            using (var db = new Contexto())
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Destroy()
        {
            //Desativa Usuario
        }
    }
}
