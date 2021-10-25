using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.Services.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.IoC.Configs
{
    class ServiceSaidasEntradasNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISaidasEntradasService>().To<SaidasEntradasService>();
        }
    }
}
