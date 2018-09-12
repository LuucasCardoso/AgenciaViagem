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
            usuarioDB = dao.ReadByUsername(user);
            if (usuarioDB == null) return false;
            if(usuarioDB.Password == pass && usuarioDB.Ativo)
            {
                //Sucesso
                return true;
            }
            else
            {
                //Usuário/Senha incorreto(s) ou Usuário Desativado!
                return false;
            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            dao.Create(usuario);
        }

        public Usuario BuscarUsuarioPorNome(string user)
        {
             return dao.ReadByUsername(user);
        }
    }
}
