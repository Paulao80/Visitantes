using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        object[] GetVeiculosArray();

        Veiculo FindByPlaca(string placa);
    }
}
