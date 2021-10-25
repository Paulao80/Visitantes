using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface IVisitanteRepository : IRepository<Visitante>
    {
        object[] GetVisitantesArray();

        Visitante FindByRgCnh(string RgCnh);
    }
}
