using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class PassagemDAO
    {
        public void Create(Passagem passagem)
        {
            using (var db = new Contexto())
            {
                db.Passagens.Add(passagem);
                db.SaveChanges();
            }

        }
        public IList<Passagem> List()
        {
            using (var db = new Contexto())
            {
                return db.Passagens.ToList();
            }
        }
        public Passagem FindById(Passagem passagem)
        {
            using (var db = new Contexto())
            {
                return db.Passagens.Find(passagem.PassagemId);
            }
        }
        public void Delete(Passagem passagem)
        {
            using (var db = new Contexto())
            {
                Passagem passagemDB = FindById(passagem);

                if (passagemDB != null)
                {
                    db.Passagens.Attach(passagem);
                    db.Passagens.Remove(passagem);
                    db.SaveChanges();
                }
            }
        }
    }
}
