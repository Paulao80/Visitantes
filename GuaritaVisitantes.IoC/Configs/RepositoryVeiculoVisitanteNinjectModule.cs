using Ninject.Modules;
using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryVeiculoVisitanteNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVeiculoVisitanteRepository>().To<VeiculoVisitanteRepository>();
        }
    }
}
