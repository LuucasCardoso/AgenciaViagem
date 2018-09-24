﻿using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CidadeController
    {
        static readonly CidadeDAO dao = new CidadeDAO();

        public void CadastrarCidade(Cidade cidade)
        {
            dao.Create(cidade);
        }
        public IList<Cidade> ListarCidades()
        {
            return dao.List();
        }
        public IList<Cidade> ListarCidadesPorEstado(int id)
        {
            IList<Cidade> cidadesFiltradas = new List<Cidade>();
            IList<Cidade> cidades = dao.List();
            foreach (var c in cidades)
            {
                if (c.EstadoId == id)
                {
                    cidadesFiltradas.Add(c);
                }
            }
            return cidadesFiltradas;
        }
        public Cidade BuscarPorId(int id)
        {
            return dao.FindById(id);
        }
        public void EditarCidade(Cidade cidade)
        {
            dao.Update(cidade);
        }
        public void ExcluirHotel(Cidade cidade)
        {
            dao.Delete(cidade);
        }
    }
}
