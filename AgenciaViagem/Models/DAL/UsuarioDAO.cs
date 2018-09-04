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
        public void Create()
        {
            //Cria Usuario
        }
        public Usuario Show(string user)
        {
            var usuariodb = from u in db.Usuarios
                        where u.User == user
                        select u;
            return usuariodb.First();
        }
        public void Destroy()
        {
            //Desativa Usuario
        }
    }
}
