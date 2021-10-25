using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class EntradasSaidasRepository : IEntradasSaidasRepository
    {

        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public IEnumerable<EntradasSaidas> GetAll()
        {
            return context.EntradasSaidas.ToList();
        }

        public IEnumerable<EntradasSaidas> GetAll(DateTime date)
        {
            return GetAll().Where(x => x.Data.Date == date.Date).ToList();
        }

        public EntradasSaidas FindById(int id)
        {
            return context.EntradasSaidas.Where(x => x.EntradasSaidasId == id).FirstOrDefault();
        }

        public int Count()
        {
            return context.EntradasSaidas.Count();
        }

        public void Add(EntradasSaidas entity)
        {
            context.EntradasSaidas.Add(entity);
            context.SaveChanges();
        }

        public void Update(EntradasSaidas entity)
        {
            context.Set<EntradasSaidas>().AddOrUpdate(entity);
            //context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(EntradasSaidas entity)
        {
            context.EntradasSaidas.Remove(FindById(entity.EntradasSaidasId));
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<EntradasSaidas> GetEntradas()
        {
            return GetAll().Where(x => x.Tipo == Entities.Models.Enums.Tipo.Entrada).ToList();
        }

        public IEnumerable<EntradasSaidas> GetEntradas(DateTime date)
        {
            return GetEntradas().Where(x => x.Data.Date == date.Date).ToList();
        }

        public IEnumerable<EntradasSaidas> GetEntradas(DateTime dateIni, DateTime dateEnd)
        {
            return GetEntradas().Where(x => x.Data >= dateIni && x.Data <= dateEnd).ToList();
        }

        public IEnumerable<EntradasSaidas> GetSaidas()
        {
            return GetAll().Where(x => x.Tipo == Entities.Models.Enums.Tipo.Saida).ToList();
        }

        public IEnumerable<EntradasSaidas> GetSaidas(DateTime date)
        {
            return GetSaidas().Where(x => x.Data.Date == date.Date).ToList();
        }

        public IEnumerable<EntradasSaidas> GetSaidas(DateTime dateIni, DateTime dateEnd)
        {
            return GetSaidas().Where(x => x.Data >= dateIni && x.Data <= dateEnd).ToList();
        }

        public IEnumerable<EntradasSaidas> GetVisitantes()
        {
            return (from e in GetEntradas()
                    where !(from s in GetSaidas()
                            select s.EntradaId)
                            .Contains(e.EntradasSaidasId)
                    select e).ToList();
        }

        public IEnumerable<EntradasSaidas> GetVisitantes(DateTime date)
        {
            return GetVisitantes().Where(x => x.Data.Date == date.Date).ToList();
        }

        public object[] GetEntradasArray()
        {
            return GetVisitantes().Select(x => new
            {
                id = x.EntradasSaidasId,
                text = x.EntradasSaidasId + " - " + x.Visitante.Nome
            }).ToArray();
        }

        public IEnumerable<EntradasSaidas> FilterByEntradaId(int EntradaId)
        {
            return GetSaidas().Where(x => x.EntradaId == EntradaId).ToList();
        }
    }
}
