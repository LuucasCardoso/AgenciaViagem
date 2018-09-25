using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class PacoteDAO
    {
        public void Create(Pacote pacote)
        {
            using (var db = new Contexto())
            {
                db.Pacotes.Add(pacote);
                db.SaveChanges();
            }

        }
        public Pacote Find(Pacote pacote)
        {
            using (var db = new Contexto())
            {
                return db.Pacotes.Find(pacote.PacoteId);
            }
        }
        public Pacote FindById(int id)
        {
            using (var db = new Contexto())
            {
                return db.Pacotes.Find(id);
            }
        }
        public IList<Pacote> List()
        {
            using (var db = new Contexto())
            {
                return db.Pacotes.ToList();
            }
        }
        public void Update(Pacote pacote)
        {
            using (var db = new Contexto())
            {
                db.Entry(pacote).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(Pacote pacote)
        {
            using (var db = new Contexto())
            {
                Pacote pacoteDB = Find(pacote);

                if (pacoteDB != null)
                {
                    db.Pacotes.Attach(pacote);
                    db.Pacotes.Remove(pacote);
                    db.SaveChanges();
                }
            }
        }
    }
}
