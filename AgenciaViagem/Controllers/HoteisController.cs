using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class HoteisController
    {        
        static readonly HoteisDAO dao = new HoteisDAO();

        public void CadastrarHotel(Hotel hotel)
        {
            dao.Create(hotel);
        }
        public IList<Hotel> ListarHotel()
        {
            return dao.List();
        }
        public void EditarHotel(Hotel hotel )
        {
            dao.Update(hotel);
        }
        public void ExcluirHoteis(Hotel hotel)
        {
            dao.Delete(hotel);
        }
    }
}
