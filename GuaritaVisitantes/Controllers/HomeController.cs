using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaritaVisitantes.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {


        private readonly IEntradasSaidasService _EntradasSaidasService;

        public HomeController(IEntradasSaidasService entradasSaidasService)
        {
            _EntradasSaidasService = entradasSaidasService;
        }

        public ActionResult Index()
        {
            var entradas = _EntradasSaidasService.GetEntradas(DateTime.Today).ToList();
            var saidas = _EntradasSaidasService.GetSaidas(DateTime.Today).ToList();

            var visitantes = _EntradasSaidasService.GetVisitantes(DateTime.Today).ToList();


            ViewBag.entradas = entradas.Count();
            ViewBag.saidas = saidas.Count();
            ViewBag.visitantes = visitantes;

            return View();
        }

        public JsonResult GetImagem()
        {
            string IdUser = User.Identity.GetUserId();
            var usuario = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Users.FirstOrDefault(x => x.Id == IdUser);

            string path = Path.Combine(Server.MapPath("~/Users/Imagens"), IdUser);

            if (System.IO.File.Exists(path + ".jpg"))
            {
                return Json(new { User = usuario.NomeCompleto, Foto = "data:image/jpg;base64," + Convert.ToBase64String(FileToByteArray(path + ".jpg")) });
            }
            else if (System.IO.File.Exists(path + ".jpeg"))
            {
                return Json(new { User = usuario.NomeCompleto, Foto = "data:image/jpeg;base64," + Convert.ToBase64String(FileToByteArray(path + ".jpeg")) });
            }
            else if (System.IO.File.Exists(path + ".png"))
            {
                return Json(new { User = usuario.NomeCompleto, Foto = "data:image/png;base64," + Convert.ToBase64String(FileToByteArray(path + ".png")) });
            }
            else
            {
                return Json(new { User = usuario.NomeCompleto, Foto = "null" });
            }
        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = System.IO.File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }
    }
}