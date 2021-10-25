using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositorySaidasEntradasNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<ISaidasEntradasRepository>().To<SaidasEntradasRepository>();
        }

    }
}
