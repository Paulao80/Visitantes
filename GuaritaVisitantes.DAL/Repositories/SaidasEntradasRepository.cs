using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class SaidasEntradasRepository : ISaidasEntradasRepository
    {

        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public void Add(SaidasEntradas entity)
        {
            context.SaidasEntradas.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.SaidasEntradas.Count();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<SaidasEntradas> FilterBySaidaId(int SaidaId)
        {
            return GetEntradas().Where(x => x.SaidaId == SaidaId).ToList();
        }

        public SaidasEntradas FindById(int id)
        {
            return context.SaidasEntradas.Where(x => x.SaidaEntradaId == id).FirstOrDefault();
        }

        public IEnumerable<SaidasEntradas> GetAll(DateTime date)
        {
            return GetAll().Where(x => x.Data.Date == date.Date).ToList();
        }

        public IEnumerable<SaidasEntradas> GetAll()
        {
            return context.SaidasEntradas.ToList();
        }

        public IEnumerable<SaidasEntradas> GetEntradas()
        {
            return GetAll().Where(x => x.Tipo == Entities.Models.Enums.Tipo.Entrada).ToList();
        }

        public IEnumerable<SaidasEntradas> GetEntradas(DateTime date)
        {
            return GetEntradas().Where(x => x.Data.Date == date.Date).ToList();
        }

        public IEnumerable<SaidasEntradas> GetEntradas(DateTime dateIni, DateTime dateEnd)
        {
            return GetEntradas().Where(x => x.Data >= dateIni && x.Data <= dateEnd).ToList();
        }

        public IEnumerable<SaidasEntradas> GetSaidas()
        {
            return GetAll().Where(x => x.Tipo == Entities.Models.Enums.Tipo.Saida).ToList();
        }

        public IEnumerable<SaidasEntradas> GetSaidas(DateTime date)
        {
            return GetSaidas().Where(x => x.Data.Date == date.Date).ToList();
        }

        public IEnumerable<SaidasEntradas> GetSaidas(DateTime dateIni, DateTime dateEnd)
        {
            return GetSaidas().Where(x => x.Data >= dateIni && x.Data <= dateEnd).ToList();
        }

        public object[] GetSaidasArray()
        {
            return GetVeiculos().Select(x => new
            {
                id = x.SaidaEntradaId,
                text = x.SaidaEntradaId + " - " + x.Veiculo.Placa + " - " + x.Veiculo.Descricao
            }).ToArray();
        }

        public IEnumerable<SaidasEntradas> GetVeiculos()
        {
            return (from s in GetSaidas()
                    where !(from e in GetEntradas()
                            select e.SaidaId)
                            .Contains(s.SaidaEntradaId)
                    select s).ToList();
        }

        public IEnumerable<SaidasEntradas> GetVeiculos(DateTime date)
        {
            return GetVeiculos().Where(x => x.Data.Date == date.Date).ToList();
        }

        public void Remove(SaidasEntradas entity)
        {
            context.SaidasEntradas.Remove(FindById(entity.SaidaEntradaId));
            context.SaveChanges();
        }

        public void Update(SaidasEntradas entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<SaidasEntradas>().AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
