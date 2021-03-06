using GuaritaVisitantes.Reports.Models;
using GuaritaVisitantes.Reports.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportEntradaGuaritaNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IEntradaGuaritaReport>().To<EntradaGuaritaReport>();
        }

    }
}
