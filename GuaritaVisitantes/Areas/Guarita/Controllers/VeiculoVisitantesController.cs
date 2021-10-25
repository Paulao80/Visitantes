using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Models;
using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class VeiculoVisitantesController : Controller
    {
        private readonly IVeiculoVisitanteService _VeiculoVisitanteService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public VeiculoVisitantesController(IVeiculoVisitanteService veiculoVisitanteService)
        {
            _VeiculoVisitanteService = veiculoVisitanteService;
        }

        // GET: Guarita/VeiculoVisitantes
        public ActionResult Index()
        {
            return View(_VeiculoVisitanteService.GetAll());
        }

        // GET: Guarita/VeiculoVisitantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VeiculoVisitanteDTO veiculo = _VeiculoVisitanteService.FindById((int)id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.Usuario = _Context.Users.Find(veiculo.UserId).NomeCompleto;

            return View(veiculo);
        }

        // GET: Guarita/VeiculoVisitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guarita/VeiculoVisitantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoVisitanteDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_VeiculoVisitanteService.FindByPlaca(model.Placa) == null)
                    {
                        model.UserId = User.Identity.GetUserId();

                        _VeiculoVisitanteService.Add(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("Placa", "Veiculo já cadastrado!");            
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Guarita/VeiculoVisitantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VeiculoVisitanteDTO veiculo = _VeiculoVisitanteService.FindById((int)id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);
        }

        // POST: Guarita/VeiculoVisitantes/Edit/5
        [HttpPost]
        public ActionResult Edit(VeiculoVisitanteDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veiculo = _VeiculoVisitanteService.FindByPlaca(model.Placa);

                    if (veiculo == null || veiculo.VeiculoId == model.VeiculoId)
                    {
                        _VeiculoVisitanteService.Update(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("Placa", "Veiculo já cadastrado!");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Deletar(FormCollection formCollection)
        {
            var itens = formCollection["ID"].Split(new char[] { ',' });

            foreach (var item in itens)
            {
                int id = int.Parse(item);
                var veiculo = _VeiculoVisitanteService.FindById(id);
                _VeiculoVisitanteService.Remove(veiculo);
            }

            return RedirectToAction("Index", "VeiculoVisitantes", new { area = "Guarita" });
        }

        public JsonResult GetVeiculos()
        {
            return Json(_VeiculoVisitanteService.GetVeiculosArray());
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            _VeiculoVisitanteService.Dispose();
            base.Dispose(disposing);
        }
    }
}