using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.DTO.Models.Enums;
using GuaritaVisitantes.Models;
using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
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
    public class SaidasController : Controller
    {
        private readonly ISaidasEntradasService _SaidasEntradasService;
        private readonly INotificationService _NotificationService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public SaidasController(ISaidasEntradasService saidasEntradasService, INotificationService notificationService)
        {
            _SaidasEntradasService = saidasEntradasService;
            _NotificationService = notificationService;
        }

        // GET: Transporte/Saidas
        public ActionResult Index()
        {
            return View(_SaidasEntradasService.GetSaidas());
        }

        // GET: Transporte/Saidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var saidasEntradasDTO = _SaidasEntradasService.FindById((int)id);

            if(saidasEntradasDTO == null)
            {
                return HttpNotFound();
            }

            ViewBag.Usuario = _Context.Users.Find(saidasEntradasDTO.UserId).NomeCompleto;

            return View(saidasEntradasDTO);
        }

        // GET: Transporte/Saidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Saidas/Create
        [HttpPost]
        public ActionResult Create(SaidasEntradasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Tipo = Tipo.Saida;
                    model.Data = DateTime.Now;
                    model.UserId = User.Identity.GetUserId();

                    _SaidasEntradasService.Add(model);

                    var Role = _Context.Roles.Where(x => x.Name == "Transporte").FirstOrDefault();
                    if (Role != null)
                    {
                        foreach (var user in Role.Users.ToList())
                        {
                            _NotificationService.Add(NotificationType.SaidaTransporte, user.UserId);
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

        // GET: Transporte/Saidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var saidasEntradasDTO = _SaidasEntradasService.FindById((int)id);

            if (saidasEntradasDTO == null)
            {
                return HttpNotFound();
            }

            return View(saidasEntradasDTO);
        }

        // POST: Transporte/Saidas/Edit/5
        [HttpPost]
        public ActionResult Edit(SaidasEntradasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _SaidasEntradasService.Update(model);

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
                var saida = _SaidasEntradasService.FindById(id);
                _SaidasEntradasService.Remove(saida);
            }

            return RedirectToAction("Index", "Saidas", new { area = "Transporte" });
        }

        public JsonResult GetSaidas()
        {
            return Json(_SaidasEntradasService.GetSaidasArray());
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            _NotificationService.Dispose();
            _SaidasEntradasService.Dispose();
            base.Dispose(disposing);
        }
    }
}
