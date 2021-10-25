using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class VeiculoVisitanteRepository : IVeiculoVisitanteRepository
    {
        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public void Add(VeiculoVisitante entity)
        {
            context.VeiculoVisitantes.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.VeiculoVisitantes.Count();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public VeiculoVisitante FindById(int id)
        {
            return context.VeiculoVisitantes.Where(x => x.VeiculoId == id).FirstOrDefault();
        }

        public VeiculoVisitante FindByPlaca(string placa)
        {
            return GetAll().Where(x => x.Placa.Equals(placa)).FirstOrDefault();
        }

        public IEnumerable<VeiculoVisitante> GetAll()
        {
            return context.VeiculoVisitantes.ToList();
        }

        public object[] GetVeiculosArray()
        {
            return GetAll().Select(x => new
            {
                id = x.VeiculoId,
                text = x.Placa + " - " + x.Descricao

            }).ToArray();
        }

        public void Remove(VeiculoVisitante entity)
        {
            context.VeiculoVisitantes.Remove(FindById(entity.VeiculoId));
            context.SaveChanges();
        }

        public void Update(VeiculoVisitante entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<VeiculoVisitante>().AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
