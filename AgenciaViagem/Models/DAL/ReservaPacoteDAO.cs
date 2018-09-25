using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class ReservaPacoteDAO
    {
        public void Create(ReservaPacote reservaPacote)
        {
            using (var db = new Contexto())
            {
                db.ReservasPacotes.Add(reservaPacote);
                db.SaveChanges();
            }

        }
        public IList<ReservaPacote> List()
        {
            using (var db = new Contexto())
            {
                return db.ReservasPacotes.ToList();
            }
        }
        public ReservaPacote FindById(ReservaPacote reservaPacote)
        {
            using (var db = new Contexto())
            {
                return db.ReservasPacotes.Find(reservaPacote.ReservaPacoteId);
            }
        }
        public void Delete(ReservaPacote reservaPacote)
        {
            using (var db = new Contexto())
            {
                ReservaPacote reservaPacoteDB = FindById(reservaPacote);

                if (reservaPacoteDB != null)
                {
                    db.ReservasPacotes.Attach(reservaPacote);
                    db.ReservasPacotes.Remove(reservaPacote);
                    db.SaveChanges();
                }
            }
        }
    }
}
