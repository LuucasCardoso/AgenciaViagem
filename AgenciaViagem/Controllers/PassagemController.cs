using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class PassagemController
    {
        static readonly PassagemDAO dao = new PassagemDAO();

        public void CadastrarPassagem(Passagem passagem)
        {
            dao.Create(passagem);
        }
        public IList<Passagem> ListarPassagens()
        {
            return dao.List();
        }
        public void ExcluirPassagem(Passagem passagem)
        {
            dao.Delete(passagem);
        }
    }
}
