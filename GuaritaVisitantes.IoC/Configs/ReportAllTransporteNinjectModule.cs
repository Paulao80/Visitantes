using GuaritaVisitantes.Reports.Interfaces;
using GuaritaVisitantes.Reports.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportAllTransporteNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAllTransporteReport>().To<AllTransporteReport>();
        }
    }
}
