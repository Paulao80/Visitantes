using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceMotoristaNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMotoristaService>().To<MotoristaService>();
        }
    }
}
