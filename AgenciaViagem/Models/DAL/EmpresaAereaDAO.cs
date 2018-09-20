using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class EmpresaAereaDAO
    {

        public void Create(EmpresaAerea empresaAerea)
        {
            using (var db = new Contexto())
            {
                db.EmpresasAereas.Add(empresaAerea);
                db.SaveChanges();
            }
            
        }
        public EmpresaAerea FindById (EmpresaAerea empresaAerea)
        {
            using (var db = new Contexto())
            {
                return db.EmpresasAereas.Find(empresaAerea.EmpresaAereaId);
            }
        }
        public IList<EmpresaAerea> List()
        {
            using (var db = new Contexto())
            {
                return db.EmpresasAereas.ToList();
            }
        }
        public void Update(EmpresaAerea empresaAerea)
        {
            using (var db = new Contexto())
            {
                db.Entry(empresaAerea).State = EntityState.Modified;
                db.SaveChanges();
            }
            
        }
        public void Delete(EmpresaAerea empresaAerea)
        {
            using (var db = new Contexto())
            {
                EmpresaAerea empresaAereaDB = FindById(empresaAerea);

                if (empresaAereaDB != null)
                {
                    db.EmpresasAereas.Attach(empresaAerea);
                    db.EmpresasAereas.Remove(empresaAerea);
                    db.SaveChanges();
                }
            }
        }
    }
}
