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
    public class EntradasController : Controller
    {

        private readonly ISaidasEntradasService _SaidasEntradasService;
        private readonly INotificationService _NotificationService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public EntradasController(ISaidasEntradasService saidasEntradasService, INotificationService notificationService)
        {
            _SaidasEntradasService = saidasEntradasService;
            _NotificationService = notificationService;
        }

        // GET: Transporte/Entradas
        public ActionResult Index()
        {
            return View(_SaidasEntradasService.GetEntradas());
        }

        // GET: Transporte/Entradas/Details/5
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

        // GET: Transporte/Entradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Entradas/Create
        [HttpPost]
        public ActionResult Create(SaidasEntradasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.SaidaId != null)
                    {
                        if(!(_SaidasEntradasService.FilterBySaidaId((int)model.SaidaId).Count() > 0))
                        {
                            var saidaEntrada = _SaidasEntradasService.FindById((int)model.SaidaId);

                            model.Tipo = Tipo.Entrada;
                            model.Data = DateTime.Now;
                            model.UserId = User.Identity.GetUserId();
                            model.VeiculoId = saidaEntrada.VeiculoId;
                            //model.MotoristaId = saidaEntrada.MotoristaId;

                            _SaidasEntradasService.Add(model);

                            var Role = _Context.Roles.Where(x => x.Name == "Transporte").FirstOrDefault();
                            if (Role != null)
                            {
                                foreach (var user in Role.Users.ToList())
                                {
                                    _NotificationService.Add(NotificationType.EntradaTransporte, user.UserId);
                                }
                            }

                            return RedirectToAction("Index");
                        }

                        ModelState.AddModelError("SaidaId", "Já possui Entrada para essa saida!");
                    }
                    else
                    {
                        ModelState.AddModelError("SaidaId", "Selecione a Saida!");
                    }
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Transporte/Entradas/Edit/5
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

        // POST: Transporte/Entradas/Edit/5
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
                var entrada = _SaidasEntradasService.FindById(id);
                _SaidasEntradasService.Remove(entrada);
            }

            return RedirectToAction("Index", "Entradas", new { area = "Transporte" });
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
