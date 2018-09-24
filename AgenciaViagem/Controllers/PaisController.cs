using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class PaisController
    {
        static readonly PaisDAO dao = new PaisDAO();

        public void CadastrarPais(Pais pais)
        {
            dao.Create(pais);
        }
        public IList<Pais> ListarPaises()
        {
            return dao.List();
        }
        public Pais BuscarPorId(int id)
        {
            return dao.FindById(id);
        }
        public void EditarPais(Pais pais)
        {
            dao.Update(pais);
        }
        public void ExcluirPais(Pais pais)
        {
            dao.Delete(pais);
        }
    }
}
