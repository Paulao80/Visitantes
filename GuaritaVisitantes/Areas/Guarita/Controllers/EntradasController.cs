using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.DTO.Models.Enums;
using GuaritaVisitantes.Models;
using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
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
    public class EntradasController : Controller
    {

        private readonly IEntradasSaidasService _EntradasSaidasService;
        private readonly INotificationService _NotificationService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public EntradasController(IEntradasSaidasService entradasSaidasService, INotificationService notificationService)
        {
            _EntradasSaidasService = entradasSaidasService;
            _NotificationService = notificationService;
        }

        // GET: Guarita/Entradas
        public ActionResult Index()
        { 
            return View(_EntradasSaidasService.GetEntradas());
        }

        // GET: Guarita/Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entradasSaidasDTO = _EntradasSaidasService.FindById((int)id);

            if(entradasSaidasDTO == null)
            {
                return HttpNotFound();
            }

            return View(entradasSaidasDTO);
        }

        // GET: Guarita/Entradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guarita/Entradas/Create
        [HttpPost]
        public ActionResult Create(EntradasSaidasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UserId = User.Identity.GetUserId();

                    model.Tipo = Tipo.Entrada;

                    model.Data = DateTime.Now;

                    model.IdUser = UserId;

                    _EntradasSaidasService.Add(model);

                    var Role = _Context.Roles.Where(x => x.Name == "Guarita").FirstOrDefault();
                    if (Role != null)
                    {
                        foreach (var user in Role.Users.ToList())
                        {
                            _NotificationService.Add(NotificationType.EntradaGuarita, user.UserId);
                        }
                    }

                    return RedirectToAction("Index");
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
                var entrada = _EntradasSaidasService.FindById(id);
                _EntradasSaidasService.Remove(entrada);
            }

            return RedirectToAction("Index", "Entradas", new { area = "Guarita" });
        }

        // GET: Guarita/Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entradasSaidasDTO = _EntradasSaidasService.FindById((int)id);

            if(entradasSaidasDTO == null)
            {
                return HttpNotFound();
            }

            return View(entradasSaidasDTO);
        }

        // POST: Guarita/Entradas/Edit/5
        [HttpPost]
        public ActionResult Edit(EntradasSaidasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EntradasSaidasService.Update(model);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        //public JsonResult GetTipos()
        //{
        //    return Json(_EntradasSaidasService.GetTiposArray());
        //}

        public JsonResult GetEntradas()
        {
            return Json(_EntradasSaidasService.GetEntradasArray());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _Context.Dispose();
            _EntradasSaidasService.Dispose();
            _NotificationService.Dispose();
        }

    }
}
