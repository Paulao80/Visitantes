using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryNotificationNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<INotificationRepository>().To<NotificationRepository>();
        }

    }
}
