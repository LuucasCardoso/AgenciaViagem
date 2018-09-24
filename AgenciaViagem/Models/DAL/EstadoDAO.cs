using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class EstadoDAO
    {
        public void Create(Estado estado)
        {
            using (var db = new Contexto())
            {
                db.Estados.Add(estado);
                db.SaveChanges();
            }

        }
        public Estado Find(Estado estado)
        {
            using (var db = new Contexto())
            {
                return db.Estados.Find(estado.EstadoId);
            }
        }
        public Estado FindById(int id)
        {
            using (var db = new Contexto())
            {
                return db.Estados.Find(id);
            }
        }
        public IList<Estado> List()
        {
            using (var db = new Contexto())
            {
                return db.Estados.ToList();
            }
        }
        public void Update(Estado estado)
        {
            using (var db = new Contexto())
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(Estado estado)
        {
            using (var db = new Contexto())
            {
                Estado estadoDB = Find(estado);

                if (estadoDB != null)
                {
                    db.Estados.Attach(estadoDB);
                    db.Estados.Remove(estadoDB);
                    db.SaveChanges();
                }
            }
        }
    }
}
