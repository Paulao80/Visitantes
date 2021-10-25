using System;
using System.IO;

namespace GuaritaVisitantes.Reports.Interfaces
{
    public interface ISaidaTransporteReport : IDisposable
    {
        void Gerar(DateTime dateIni, DateTime dateEnd);
        MemoryStream GetReport();
    }
}
