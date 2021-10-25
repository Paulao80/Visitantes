using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryVeiculoNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IVeiculoRepository>().To<VeiculoRepository>();
        }

    }
}
