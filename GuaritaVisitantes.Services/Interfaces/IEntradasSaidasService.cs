using GuaritaVisitantes.DTO.Models;
using System;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IEntradasSaidasService : IService<EntradasSaidasDTO> 
    {

        IEnumerable<EntradasSaidasDTO> GetEntradas();

        IEnumerable<EntradasSaidasDTO> GetEntradas(DateTime date);

        IEnumerable<EntradasSaidasDTO> GetSaidas();

        IEnumerable<EntradasSaidasDTO> GetSaidas(DateTime date);

        object[] GetEntradasArray();

        IEnumerable<EntradasSaidasDTO> GetAll(DateTime date);

        IEnumerable<EntradasSaidasDTO> GetVisitantes();

        IEnumerable<EntradasSaidasDTO> GetVisitantes(DateTime date);

        IEnumerable<EntradasSaidasDTO> FilterByEntradaId(int EntradaId);

    }
}
