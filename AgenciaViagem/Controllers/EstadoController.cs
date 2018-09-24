using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EstadoController
    {
        static readonly EstadoDAO dao = new EstadoDAO();

        public void CadastrarEstado(Estado estado)
        {
            dao.Create(estado);
        }
        public IList<Estado> ListarEstados()
        {
            return dao.List();
        }
        public IList<Estado> ListarEstadosPorPais(int id)
        {
            IList<Estado> estadosFiltrados = new List<Estado>();
            IList<Estado> estados = dao.List();
            foreach (var e in estados)
            {
                if (e.PaisId == id)
                {
                    estadosFiltrados.Add(e);
                }
            }
            return estadosFiltrados;
        }
        public Estado BuscarPorId(int id)
        {
            return dao.FindById(id);
        }
        public void EditarEstado(Estado estado)
        {
            dao.Update(estado);
        }
        public void ExcluirEstado(Estado estado)
        {
            dao.Delete(estado);
        }
    }
}
