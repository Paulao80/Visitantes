using GuaritaVisitantes.Reports.Interfaces;
using GuaritaVisitantes.Reports.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportAllGuaritaNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAllGuaritaReport>().To<AllGuaritaReport>();
        }
    }
}
