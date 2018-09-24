using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class HotelController
    {
        static readonly HotelDAO dao = new HotelDAO();

        public void CadastrarHotel(Hotel hotel)
        {
            dao.Create(hotel);
        }
        public IList<Hotel> ListarHoteis()
        {
            return dao.List();
        }
        public void EditarHotel(Hotel hotel)
        {
            dao.Update(hotel);
        }
        public void ExcluirHotel(Hotel hotel)
        {
            dao.Delete(hotel);
        }
    }
}
