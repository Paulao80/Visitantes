using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {

        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public void Add(Motorista entity)
        {
            context.Motoristas.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Motoristas.Count();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Motorista FindByCnhRg(string CnhRg)
        {
            return GetAll().Where(x => x.CnhRg.Equals(CnhRg)).FirstOrDefault();
        }

        public Motorista FindById(int id)
        {
            return context.Motoristas.Where(x => x.MotoristaId == id).FirstOrDefault();
        }

        public IEnumerable<Motorista> GetAll()
        {
            return context.Motoristas.ToList();
        }

        public object[] GetMotoristaArray()
        {
            return GetAll().Select(x => new
            {
                id = x.MotoristaId,
                text = x.Nome
            }).ToArray();
        }

        public void Remove(Motorista entity)
        {
            context.Motoristas.Remove(FindById(entity.MotoristaId));
            context.SaveChanges();
        }

        public void Update(Motorista entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<Motorista>().AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
