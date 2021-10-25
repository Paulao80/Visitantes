using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GuaritaVisitantes.Util;
using System.Net;

namespace GuaritaVisitantes.Areas.Guarita.Controllers
{
    [Authorize(
        Roles = "Administrador, Analista, Desenvolvedor, Guarita"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
    )]
    public class VisitantesController : Controller
    {
        private readonly IVisitanteService _VisitanteService;

        public VisitantesController(IVisitanteService visitanteService)
        {
            _VisitanteService = visitanteService;
        }

        // GET: Guarita/Visitantes
        public ActionResult Index()
        {
            return View(_VisitanteService.GetAll());
        }

        // GET: Guarita/Visitantes/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VisitanteDTO visitante = _VisitanteService.FindById((int)id);

            if(visitante == null)
            {
                return HttpNotFound();
            }

            visitante.CnhRgPath = Converter.FileToData(visitante.CnhRgPath);

            visitante.FotoPath = Converter.FileToData(visitante.FotoPath);

            return View(visitante);
        }

        // GET: Guarita/Visitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guarita/Visitantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitanteDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_VisitanteService.FindByRgCnh(model.CnhRg) == null)
                    {
                        if (model.CnhRgFile != null)
                        {
                            string path = Path.Combine(Server.MapPath("~/Arquivos/Imagens"), DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.CnhRg + "-" + "cnhrg" + Path.GetExtension(model.CnhRgFile.FileName));
                            model.CnhRgFile.SaveAs(path);
                            model.CnhRgPath = path;
                        }

                        if (model.FotoPath != null)
                        {
                            if (System.IO.File.Exists(model.FotoPath))
                            {
                                string pathDestination = Path.Combine(Server.MapPath("~/Arquivos/Imagens"), DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.CnhRg + "-" + "foto" + Path.GetExtension(model.FotoPath));
                                System.IO.File.Move(model.FotoPath, pathDestination);
                                model.FotoPath = pathDestination;
                            }
                        }

                        model.IdUser = User.Identity.GetUserId();

                        _VisitanteService.Add(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("CnhRg", "Esse Visitante já foi cadastrado!");
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

            foreach(var item in itens)
            {
                int id = int.Parse(item);
                var visitante = _VisitanteService.FindById(id);
                _VisitanteService.Remove(visitante);
            }

            return RedirectToAction("Index", "Visitantes", new { area = "Guarita" });
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase image)
        {
            if(image != null)
            {
                string path = Path.Combine(Server.MapPath("~/Arquivos/Uploads"), DateTime.Now.ToString("ddMMyyyyHHmmss") + " - foto" + Path.GetExtension(image.FileName));
                image.SaveAs(path);
                return Json(new
                {
                    result = true,
                    path
                });
            }

            return Json(new { 
                result = false
            });
        }

        // GET: Guarita/Visitantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visitanteDTO = _VisitanteService.FindById((int)id);
            if(visitanteDTO == null)
            {
                return HttpNotFound();
            }

            return View(visitanteDTO);
        }

        // POST: Guarita/Visitantes/Edit/5
        [HttpPost]
        public ActionResult Edit(VisitanteDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var visitante = _VisitanteService.FindByRgCnh(model.CnhRg);

                    if (visitante == null || visitante.VisitanteId == model.VisitanteId)
                    {
                        if (model.CnhRgFile != null)
                        {
                            string path = Path.Combine(Server.MapPath("~/Arquivos/Imagens"), DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.CnhRg + "-" + "cnhrg" + Path.GetExtension(model.CnhRgFile.FileName));
                            model.CnhRgFile.SaveAs(path);
                            model.CnhRgPath = path;
                        }

                        string pathDestination = Path.Combine(Server.MapPath("~/Arquivos/Imagens"), DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.CnhRg + "-" + "foto" + Path.GetExtension(model.FotoPath));
                        System.IO.File.Move(model.FotoPath, pathDestination);
                        model.FotoPath = pathDestination;

                        _VisitanteService.Update(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("CnhRg", "Esse Visitante já foi cadastrado!");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        public JsonResult GetVisitantes()
        {
            return Json(_VisitanteService.GetVisitantesArray());
        }

        protected override void Dispose(bool disposing)
        {
            _VisitanteService.Dispose();
            base.Dispose(disposing);
        }
    }
}
