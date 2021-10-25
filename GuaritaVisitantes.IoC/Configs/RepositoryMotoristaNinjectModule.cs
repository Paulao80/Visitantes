using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryMotoristaNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMotoristaRepository>().To<MotoristaRepository>();
        }
    }
}
