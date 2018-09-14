using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class QuartoController
    {
        static readonly QuartoDAO dao = new QuartoDAO();

        public void CadastrarQuarto(Quarto quarto)
        {
            dao.Create(quarto);
        }
    }
}
