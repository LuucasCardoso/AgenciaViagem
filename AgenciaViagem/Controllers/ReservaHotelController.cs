using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ReservaHotelController
    {
        static readonly ReservaHotelDAO dao = new ReservaHotelDAO();

        public void CadastrarReservaHotel(ReservaHotel reservaHotel)
        {
            dao.Create(reservaHotel);
        }
        public IList<ReservaHotel> ListarReservasHotel()
        {
            return dao.List();
        }
        public void ExcluirReservaHotel(ReservaHotel reservaHotel)
        {
            dao.Delete(reservaHotel);
        }
    }
}
