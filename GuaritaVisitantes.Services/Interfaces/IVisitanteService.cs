using GuaritaVisitantes.DTO.Models;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IVisitanteService : IService<VisitanteDTO>
    {
        object[] GetVisitantesArray();

        VisitanteDTO FindByRgCnh(string RgCnh);
    }
}
