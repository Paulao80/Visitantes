using GuaritaVisitantes.DTO.Models;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IMotoristaService : IService<MotoristaDTO>
    {
        object[] GetMotoristaArray();

        MotoristaDTO FindByCnhRg(string CnhRg);
    }
}
