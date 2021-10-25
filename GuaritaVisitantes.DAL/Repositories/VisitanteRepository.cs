using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class VisitanteRepository : IVisitanteRepository
    {

        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public IEnumerable<Visitante> GetAll()
        {
            return context.Visitantes.ToList();
        }

        public Visitante FindById(int id)
        {
            return context.Visitantes.Where(x => x.VisitanteId == id).FirstOrDefault();
        }

        public int Count()
        {
            return context.Visitantes.Count();
        }

        public void Add(Visitante entity)
        {
            context.Visitantes.Add(entity);
            context.SaveChanges();
        }

        public void Update(Visitante entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<Visitante>().AddOrUpdate(entity);
            context.SaveChanges();
        }

        public void Remove(Visitante entity)
        {
            context.Visitantes.Remove(FindById(entity.VisitanteId));
            context.SaveChanges();
        }

        public object[] GetVisitantesArray()
        {
            return GetAll().Select(x => new
            {
                id = x.VisitanteId,
                text = x.Nome
            }).ToArray(); 
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Visitante FindByRgCnh(string RgCnh)
        {
            return GetAll().Where(x => x.CnhRg.Equals(RgCnh)).FirstOrDefault();
        }
    }
}
