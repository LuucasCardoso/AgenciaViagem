using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class CarrinhoDAO
    {
        public void Create(Carrinho carrinho)
        {
            using (var db = new Contexto())
            {
                db.Carrinhos.Add(carrinho);
                db.SaveChanges();
            }

        }
        public IList<Carrinho> List()
        {
            using (var db = new Contexto())
            {
                return db.Carrinhos.ToList();
            }
        }
        public void Update(Carrinho carrinho)
        {
            using (var db = new Contexto())
            {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Carrinho FindById(Carrinho carrinho)
        {
            using (var db = new Contexto())
            {
                return db.Carrinhos.Find(carrinho.CarrinhoId);
            }
        }
        public void Delete(Carrinho carrinho)
        {
            using (var db = new Contexto())
            {
                Carrinho carrinhoDB = FindById(carrinho);

                if (carrinhoDB != null)
                {
                    db.Carrinhos.Attach(carrinho);
                    db.Carrinhos.Remove(carrinho);
                    db.SaveChanges();
                }
            }
        }
    }
}
