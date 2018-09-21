using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ListCarrinhoController
    {
        static readonly CarrinhoDAO dao = new CarrinhoDAO();

        public IList<Carrinho> ListCarrinho()
        {
            return dao.List();
        }
        public void EditarCarrinho(Carrinho carrinho)
        {
            dao.Update(carrinho);
        }
        public void ExcluirCarrinho(Carrinho carrinho)
        {
            dao.Delete(carrinho);
        }

    }
}
