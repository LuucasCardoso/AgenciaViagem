using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UsuarioController
    {
        static readonly UsuarioDAO dao = new UsuarioDAO();
        public bool AuthUsuario(string user, string pass)
        {
            Usuario usuarioDB = new Usuario();
            usuarioDB = dao.Show(user);
            if(usuarioDB.Password == pass)
            {
                //Sucesso
                return true;
            }
            else
            {
                //Acesso Negado
                return false;
            }
        }
    }
}
