using System;
using System.IO;

namespace GuaritaVisitantes.Reports.Interfaces
{
    public interface IAllGuaritaReport : IDisposable
    {
        void Gerar(DateTime dateIni, DateTime dateEnd);
        MemoryStream GetReport();
    }
}
