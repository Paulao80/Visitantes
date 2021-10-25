using GuaritaVisitantes.Entities.Models;
using System;
using System.Collections.Generic;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface IEntradasSaidasRepository : IRepository<EntradasSaidas>
    {

        IEnumerable<EntradasSaidas> GetEntradas();

        IEnumerable<EntradasSaidas> GetEntradas(DateTime date);

        IEnumerable<EntradasSaidas> GetEntradas(DateTime dateIni, DateTime dateEnd);

        IEnumerable<EntradasSaidas> GetSaidas();

        IEnumerable<EntradasSaidas> GetSaidas(DateTime date);

        IEnumerable<EntradasSaidas> GetSaidas(DateTime dateIni, DateTime dateEnd);

        IEnumerable<EntradasSaidas> GetAll(DateTime date);

        IEnumerable<EntradasSaidas> GetVisitantes();

        IEnumerable<EntradasSaidas> GetVisitantes(DateTime date);

        object[] GetEntradasArray();

        IEnumerable<EntradasSaidas> FilterByEntradaId(int EntradaId);
    }
}
