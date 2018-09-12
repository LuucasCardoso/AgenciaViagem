using Models.Entities;
using System;
using System.Collections.Generic;
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
        public Usuario Read(int id)
        {
            var usuariodb = from u in db.Usuarios
                            where u.UsuarioId == id
                            select u;
            return usuariodb.FirstOrDefault();
        }
        public Usuario ReadByUsername(string user)
        {
            var usuariodb = from u in db.Usuarios
                        where u.User == user
                        select u;
            return usuariodb.FirstOrDefault();
        }
        public void Destroy()
        {
            //Desativa Usuario
        }
    }
}
