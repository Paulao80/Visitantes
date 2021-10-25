using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        object[] GetMotoristaArray();

        Motorista FindByCnhRg(string CnhRg);
    }
}
