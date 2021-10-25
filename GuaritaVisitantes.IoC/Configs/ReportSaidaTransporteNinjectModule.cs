using GuaritaVisitantes.Reports.Interfaces;
using GuaritaVisitantes.Reports.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportSaidaTransporteNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISaidaTransporteReport>().To<SaidaTransporteReport>();
        }
    }
}
