using System.Web.Mvc;

namespace GuaritaVisitantes.Controllers
{

    [Authorize(
        Roles = "Administrador, Analista, Desenvolvedor"
    )]
    public class UserController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}