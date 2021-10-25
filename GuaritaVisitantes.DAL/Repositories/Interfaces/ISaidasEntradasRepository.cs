using GuaritaVisitantes.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface ISaidasEntradasRepository : IRepository<SaidasEntradas>
    {
        IEnumerable<SaidasEntradas> GetAll(DateTime date);
        IEnumerable<SaidasEntradas> GetSaidas();
        IEnumerable<SaidasEntradas> GetSaidas(DateTime date);
        IEnumerable<SaidasEntradas> GetSaidas(DateTime dateIni, DateTime dateEnd);
        IEnumerable<SaidasEntradas> GetEntradas();
        IEnumerable<SaidasEntradas> GetEntradas(DateTime date);
        IEnumerable<SaidasEntradas> GetEntradas(DateTime dateIni, DateTime dateEnd);
        IEnumerable<SaidasEntradas> GetVeiculos();
        IEnumerable<SaidasEntradas> GetVeiculos(DateTime date);
        object[] GetSaidasArray();
        IEnumerable<SaidasEntradas> FilterBySaidaId(int SaidaId);
    }
}
