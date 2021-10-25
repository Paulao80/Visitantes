using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceVeiculoNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IVeiculoService>().To<VeiculoService>();
        }

    }
}
