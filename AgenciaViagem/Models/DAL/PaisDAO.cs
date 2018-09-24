using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class PaisDAO
    {
        public void Create(Pais pais)
        {
            using (var db = new Contexto())
            {
                db.Paises.Add(pais);
                db.SaveChanges();
            }

        }
        public Pais Find(Pais pais)
        {
            using (var db = new Contexto())
            {
                return db.Paises.Find(pais.PaisId);
            }
        }
        public Pais FindById(int id)
        {
            using (var db = new Contexto())
            {
                return db.Paises.Find(id);
            }
        }
        public IList<Pais> List()
        {
            using (var db = new Contexto())
            {
                return db.Paises.ToList();
            }
        }
        public void Update(Pais pais)
        {
            using (var db = new Contexto())
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(Pais pais)
        {
            using (var db = new Contexto())
            {
                Pais paisDB = Find(pais);

                if (paisDB != null)
                {
                    db.Paises.Attach(paisDB);
                    db.Paises.Remove(paisDB);
                    db.SaveChanges();
                }
            }
        }
    }
}
