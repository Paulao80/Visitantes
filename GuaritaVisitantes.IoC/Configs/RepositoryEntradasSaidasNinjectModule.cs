using GuaritaVisitantes.DAL.Repositories;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.IoC.Configs
{
    class RepositoryEntradasSaidasNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IEntradasSaidasRepository>().To<EntradasSaidasRepository>();
        }

    }
}
