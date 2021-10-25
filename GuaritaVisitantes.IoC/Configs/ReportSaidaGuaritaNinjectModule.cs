using GuaritaVisitantes.Reports.Models;
using GuaritaVisitantes.Reports.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportSaidaGuaritaNinjectModule : NinjectModule
    {        
        public override void Load()
        {
            Bind<ISaidaGuaritaReport>().To<SaidaGuaritaReport>();
        }
    }
}
