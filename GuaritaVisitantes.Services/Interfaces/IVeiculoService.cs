using GuaritaVisitantes.DTO.Models;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IVeiculoService: IService<VeiculoDTO>
    {
        object[] GetVeiculosArray();

        VeiculoDTO FindByPlaca(string placa);
    }
}
