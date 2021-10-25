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
    class ServiceEntradasSaidasNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IEntradasSaidasService>().To<EntradasSaidasService>();
        }

    }
}
