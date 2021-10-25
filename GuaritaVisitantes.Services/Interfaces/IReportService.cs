using System;
using System.IO;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IReportService : IDisposable
    {
        MemoryStream GerarEntradaGuarita(DateTime dateIni, DateTime dateEnd);
        MemoryStream GerarSaidaGuarita(DateTime dateIni, DateTime dateEnd);
        MemoryStream GerarEntradaTransporte(DateTime dateIni, DateTime dateEnd);
        MemoryStream GerarSaidaTransporte(DateTime dateIni, DateTime dateEnd);
        MemoryStream GerarAllTransporte(DateTime dateIni, DateTime dateEnd);
        MemoryStream GerarAllGuarita(DateTime dateIni, DateTime dateEnd);
    }
}
