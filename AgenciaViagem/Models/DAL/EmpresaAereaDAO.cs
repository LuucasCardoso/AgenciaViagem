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
        public EmpresaAerea FindById (EmpresaAerea empresaAerea)
        {
            return db.EmpresasAereas.Find(empresaAerea.EmpresaAereaId);
        }
        public ICollection<EmpresaAerea> List()
        {
            return db.EmpresasAereas.ToList();
        }
        public void Update(EmpresaAerea empresaAerea)
        {
            db.Entry(empresaAerea).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(EmpresaAerea empresaAerea)
        {
            EmpresaAerea empresaAereaDB = FindById(empresaAerea);
            db.EmpresasAereas.Remove(empresaAerea);
        }
    }
}
