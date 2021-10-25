using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryVisitanteNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IVisitanteRepository>().To<VisitanteRepository>();
        }

    }
}
