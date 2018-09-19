using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EmpresaAereaController
    {
        static readonly EmpresaAereaDAO dao = new EmpresaAereaDAO();

        public void CadastrarEmpresaAerea(EmpresaAerea empresaAerea)
        {
            dao.Create(empresaAerea);
        }
        public ICollection<EmpresaAerea> ListarEmpresasAereas()
        {
            return dao.List();
        }
    }
}
