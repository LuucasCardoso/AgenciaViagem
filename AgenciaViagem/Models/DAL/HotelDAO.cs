using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class HotelDAO
    {
        public void Create(Hotel hotel)
        {
            using (var db = new Contexto())
            {
                db.Hoteis.Add(hotel);
                db.SaveChanges();
            }

        }
        public Hotel FindById(Hotel hotel)
        {
            using (var db = new Contexto())
            {
                return db.Hoteis.Find(hotel.HotelId);
            }
        }
        public IList<Hotel> List()
        {
            using (var db = new Contexto())
            {
                return db.Hoteis.ToList();
            }
        }
        public void Update(Hotel hotel)
        {
            using (var db = new Contexto())
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Delete(Hotel hotel)
        {
            using (var db = new Contexto())
            {
                Hotel hotelDB = FindById(hotel);

                if (hotelDB != null)
                {
                    db.Hoteis.Attach(hotel);
                    db.Hoteis.Remove(hotel);
                    db.SaveChanges();
                }
            }
        }
    }
}
