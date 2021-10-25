using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ReportServiceNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IReportService>().To<ReportService>();
        }

    }
}
