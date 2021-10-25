using GuaritaVisitantes.Services.Models;
using GuaritaVisitantes.Services.Interfaces;
using Ninject.Modules;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceVeiculoVisitanteNinjectModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IVeiculoVisitanteService>().To<VeiculoVisitanteService>();
        }
    }
}
