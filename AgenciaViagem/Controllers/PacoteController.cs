using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class PacoteController
    {
        static readonly PacoteDAO dao = new PacoteDAO();

        public void CadastrarPacotel(Pacote pacote)
        {
            dao.Create(pacote);
        }
        public Pacote BuscarPorId(int id)
        {
            return dao.FindById(id);
        }
        public IList<Pacote> Listarpacotes()
        {
            return dao.List();
        }
        public void EditarPacote(Pacote pacote)
        {
            dao.Update(pacote);
        }
        public void ExcluirPacote(Pacote pacote)
        {
            dao.Delete(pacote);
        }
    }
}
