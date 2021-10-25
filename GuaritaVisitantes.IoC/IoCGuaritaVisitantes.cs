using CommonServiceLocator.NinjectAdapter.Unofficial;
using GuaritaVisitantes.IoC.Configs;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace GuaritaVisitantes.IoC
{
    public class IoCGuaritaVisitantes
    {

        public IKernel Kernel { get;  }

        public IoCGuaritaVisitantes()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        private static StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new RepositoryVisitanteNinjectModule(),
                new ServiceVisitanteNinjectModule(),
                new ServiceEntradasSaidasNinjectModule(),
                new RepositoryEntradasSaidasNinjectModule(),
                new AutoMapperModule(),
                new ReportEntradaGuaritaNinjectModule(),
                new ReportSaidaGuaritaNinjectModule(),
                new ReportServiceNinjectModule(),
                new RepositoryNotificationNinjectModule(),
                new ServiceNotificationNinjectModule(),
                new RepositoryVeiculoNinjectModule(),
                new ServiceVeiculoNinjectModule(),
                new RepositoryMotoristaNinjectModule(),
                new ServiceMotoristaNinjectModule(),
                new RepositorySaidasEntradasNinjectModule(),
                new ServiceSaidasEntradasNinjectModule(),
                new ReportSaidaTransporteNinjectModule(),
                new ReportEntradaTransporteNinjectModule(),
                new ReportAllTransporteNinjectModule(),
                new RepositoryVeiculoVisitanteNinjectModule(),
                new ServiceVeiculoVisitanteNinjectModule(),
                new ReportAllGuaritaNinjectModule()
            );
        }
    }
}
