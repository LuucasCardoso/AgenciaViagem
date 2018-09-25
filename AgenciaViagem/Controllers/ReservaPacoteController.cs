using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ReservaPacoteController
    {
        static readonly ReservaPacoteDAO dao = new ReservaPacoteDAO();

        public void CadastrarReservaPacote(ReservaPacote reservaPacote)
        {
            dao.Create(reservaPacote);
        }
        public IList<ReservaPacote> ListarReservaPacote()
        {
            return dao.List();
        }
        public void ExcluirReservaPacote(ReservaPacote reservaPacote)
        {
            dao.Delete(reservaPacote);
        }
    }
}
