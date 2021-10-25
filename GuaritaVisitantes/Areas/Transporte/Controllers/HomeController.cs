using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaritaVisitantes.Areas.Transporte.Controllers
{
    [Authorize(
        Roles = "Administrador, Analista, Desenvolvedor, Transporte"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
    )]

    public class HomeController : Controller
    {

        private readonly ISaidasEntradasService _SaidasEntradasService;

        public HomeController(ISaidasEntradasService saidasEntradasService)
        {
            _SaidasEntradasService = saidasEntradasService;
        }

        // GET: Transporte/Home
        public ActionResult Index()
        {
            var saidas = _SaidasEntradasService.GetSaidas(DateTime.Today).ToList();
            var entradas = _SaidasEntradasService.GetEntradas(DateTime.Today).ToList();

            var veiculos = _SaidasEntradasService.GetVeiculos(DateTime.Today).ToList();

            ViewBag.saidas = saidas.Count();
            ViewBag.entradas = entradas.Count();
            ViewBag.veiculos = veiculos;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _SaidasEntradasService.Dispose();
            base.Dispose(disposing);
        }
    }
}