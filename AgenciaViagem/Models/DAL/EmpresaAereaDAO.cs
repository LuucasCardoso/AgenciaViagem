using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class EmpresaAereaDAO
    {
        static readonly Contexto db = new Contexto();

        public void Create(EmpresaAerea empresaAerea)
        {
            db.EmpresasAereas.Add(empresaAerea);
            db.SaveChanges();
        }
        public EmpresaAerea Read(int id)
        {
            return new EmpresaAerea();
        }
        public void Destroy()
        {
            //Desativa Usuario
        }
    }
}
