using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class CidadeDAO
    {
        public void Create(Cidade cidade)
        {
            using (var db = new Contexto())
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
            }

        }
        public Cidade Find(Cidade cidade)
        {
            using (var db = new Contexto())
            {
                return db.Cidades.Find(cidade.CidadeId);
            }
        }
        public Cidade FindById(int id)
        {
            using (var db = new Contexto())
            {
                return db.Cidades.Find(id);
            }
        }
        public IList<Cidade> List()
        {
            using (var db = new Contexto())
            {
                return db.Cidades.ToList();
            }
        }
        public void Update(Cidade cidade)
        {
            using (var db = new Contexto())
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(Cidade cidade)
        {
            using (var db = new Contexto())
            {
                Cidade cidadeDB = Find(cidade);

                if (cidadeDB != null)
                {
                    db.Cidades.Attach(cidadeDB);
                    db.Cidades.Remove(cidadeDB);
                    db.SaveChanges();
                }
            }
        }
    }
}
