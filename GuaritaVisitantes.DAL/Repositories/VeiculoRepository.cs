using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public void Add(Veiculo entity)
        {
            context.Veiculos.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Veiculos.Count();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Veiculo FindById(int id)
        {
            return context.Veiculos.Where(x => x.VeiculoId == id).FirstOrDefault();
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return context.Veiculos.ToList();
        }

        public void Remove(Veiculo entity)
        {
            context.Veiculos.Remove(FindById(entity.VeiculoId));
            context.SaveChanges();
        }

        public void Update(Veiculo entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<Veiculo>().AddOrUpdate(entity);
            context.SaveChanges();
        }

        public object[] GetVeiculosArray()
        {
            return GetAll().Select(x => new
            {
                id = x.VeiculoId,
                text = x.Placa + " - " + x.Descricao
            }).ToArray();
        }

        public Veiculo FindByPlaca(string placa)
        {
            return GetAll().Where(x => x.Placa.Equals(placa)).FirstOrDefault();
        }
    }
}
