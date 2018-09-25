using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class ReservaHotelDAO
    {
        public void Create(ReservaHotel reservaHotel)
        {
            using (var db = new Contexto())
            {
                db.ReservasHotel.Add(reservaHotel);
                db.SaveChanges();
            }

        }
        public IList<ReservaHotel> List()
        {
            using (var db = new Contexto())
            {
                return db.ReservasHotel.ToList();
            }
        }
        public ReservaHotel FindById(ReservaHotel reservaHotel)
        {
            using (var db = new Contexto())
            {
                return db.ReservasHotel.Find(reservaHotel.ReservaHotelId);
            }
        }
        public void Delete(ReservaHotel reservaHotel)
        {
            using (var db = new Contexto())
            {
                ReservaHotel reservaHotelDB = FindById(reservaHotel);

                if (reservaHotelDB != null)
                {
                    db.ReservasHotel.Attach(reservaHotel);
                    db.ReservasHotel.Remove(reservaHotel);
                    db.SaveChanges();
                }
            }
        }
    }
}
