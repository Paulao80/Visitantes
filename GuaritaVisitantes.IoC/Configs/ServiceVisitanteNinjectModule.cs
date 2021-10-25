using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceVisitanteNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IVisitanteService>().To<VisitanteService>();
        }

    }
}
