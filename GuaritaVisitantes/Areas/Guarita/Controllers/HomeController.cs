using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaritaVisitantes.Areas.Guarita.Controllers
{
    [Authorize(
        Roles = "Administrador, Analista, Desenvolvedor, Guarita"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
    )]
    public class HomeController : Controller
    {

        private readonly IEntradasSaidasService _EntradasSaidasService;

        public HomeController(IEntradasSaidasService entradasSaidasService)
        {
            _EntradasSaidasService = entradasSaidasService;
        }

        // GET: Guarita/Home
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
        protected override void Dispose(bool disposing)
        {
            _EntradasSaidasService.Dispose();
            base.Dispose(disposing);
        }
    }
}