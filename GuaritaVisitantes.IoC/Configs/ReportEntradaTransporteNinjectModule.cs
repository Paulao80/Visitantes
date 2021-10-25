using GuaritaVisitantes.Reports.Interfaces;
using GuaritaVisitantes.Reports.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportEntradaTransporteNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEntradaTransporteReport>().To<EntradaTransporteReport>();
        }
    }
}
