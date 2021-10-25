using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Reports.Interfaces
{
    public interface IEntradaGuaritaReport : IDisposable
    {
        void Gerar(DateTime dateIni, DateTime dateEnd);
        MemoryStream GetReport();
    }
}
