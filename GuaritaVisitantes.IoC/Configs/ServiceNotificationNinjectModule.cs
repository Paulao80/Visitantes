using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceNotificationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INotificationService>().To<NotificationService>();
        }

    }
}
