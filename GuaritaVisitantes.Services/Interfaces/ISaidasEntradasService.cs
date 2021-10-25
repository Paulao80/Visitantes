using GuaritaVisitantes.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface ISaidasEntradasService : IService<SaidasEntradasDTO>
    {
        IEnumerable<SaidasEntradasDTO> GetAll(DateTime date);
        IEnumerable<SaidasEntradasDTO> GetSaidas();
        IEnumerable<SaidasEntradasDTO> GetSaidas(DateTime date);
        IEnumerable<SaidasEntradasDTO> GetEntradas();
        IEnumerable<SaidasEntradasDTO> GetEntradas(DateTime date);
        IEnumerable<SaidasEntradasDTO> GetVeiculos();
        IEnumerable<SaidasEntradasDTO> GetVeiculos(DateTime date); 
        IEnumerable<SaidasEntradasDTO> FilterBySaidaId(int SaidaId);
        object[] GetSaidasArray();
    }
}
