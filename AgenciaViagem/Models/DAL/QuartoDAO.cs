using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class QuartoDAO
    {
        static readonly Contexto db = new Contexto();

        public void Create(Quarto quarto)
        {
            db.Quartos.Add(quarto);
            db.SaveChanges();
        }
        public Quarto Read (int id)
        {
            //Retorna 1 quarto
            return new Quarto();
        }
        public void Destroy()
        {
            //Desativa Usuario
        }
    }
}
