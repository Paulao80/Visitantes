using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface IVeiculoVisitanteRepository : IRepository<VeiculoVisitante>
    {
        object[] GetVeiculosArray();

        VeiculoVisitante FindByPlaca(string placa);
    }
}
