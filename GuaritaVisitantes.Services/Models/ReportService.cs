using GuaritaVisitantes.Reports.Interfaces;
using GuaritaVisitantes.Services.Interfaces;
using System;
using System.IO;

namespace GuaritaVisitantes.Services.Models
{
    public class ReportService : IReportService
    {
        private readonly IEntradaGuaritaReport _EntradaGuaritaReport;
        private readonly ISaidaGuaritaReport _SaidaGuaritaReport;
        private readonly IEntradaTransporteReport _EntradaTransporteReport;
        private readonly ISaidaTransporteReport _SaidaTransporteReport;
        private readonly IAllTransporteReport _AllTransporteReport;
        private readonly IAllGuaritaReport _AllGuaritaReport;

        public ReportService(IEntradaGuaritaReport entradaGuaritaReport, ISaidaGuaritaReport saidaGuaritaReport, IEntradaTransporteReport entradaTransporteReport, ISaidaTransporteReport saidaTransporteReport, IAllTransporteReport allTransporteReport, IAllGuaritaReport allGuaritaReport)
        {
            _EntradaGuaritaReport = entradaGuaritaReport;
            _SaidaGuaritaReport = saidaGuaritaReport;
            _EntradaTransporteReport = entradaTransporteReport;
            _SaidaTransporteReport = saidaTransporteReport;
            _AllTransporteReport = allTransporteReport;
            _AllGuaritaReport = allGuaritaReport;
        }

        public MemoryStream GerarEntradaGuarita(DateTime dateIni, DateTime dateEnd)
        {
            _EntradaGuaritaReport.Gerar(dateIni, dateEnd);
            return _EntradaGuaritaReport.GetReport();
        }

        public MemoryStream GerarSaidaGuarita(DateTime dateIni, DateTime dateEnd)
        {
            _SaidaGuaritaReport.Gerar(dateIni, dateEnd);
            return _SaidaGuaritaReport.GetReport();
        }

        public void Dispose()
        {
            _EntradaGuaritaReport.Dispose();
            _SaidaGuaritaReport.Dispose();
        }

        public MemoryStream GerarEntradaTransporte(DateTime dateIni, DateTime dateEnd)
        {
            _EntradaTransporteReport.Gerar(dateIni, dateEnd);
            return _EntradaTransporteReport.GetReport();
        }

        public MemoryStream GerarSaidaTransporte(DateTime dateIni, DateTime dateEnd)
        {
            _SaidaTransporteReport.Gerar(dateIni, dateEnd);
            return _SaidaTransporteReport.GetReport();
        }

        public MemoryStream GerarAllTransporte(DateTime dateIni, DateTime dateEnd)
        {
            _AllTransporteReport.Gerar(dateIni, dateEnd);
            return _AllTransporteReport.GetReport();
        }

        public MemoryStream GerarAllGuarita(DateTime dateIni, DateTime dateEnd)
        {
            _AllGuaritaReport.Gerar(dateIni, dateEnd);
            return _AllGuaritaReport.GetReport();
        }
    }
}
