using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuaritaVisitantes.Startup))]
namespace GuaritaVisitantes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
