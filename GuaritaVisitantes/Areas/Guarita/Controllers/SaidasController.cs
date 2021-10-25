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
    public class SaidasController : Controller
    {

        private readonly IEntradasSaidasService _EntradasSaidasService;
        private readonly INotificationService _NotificationService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public SaidasController(IEntradasSaidasService entradasSaidasService, INotificationService notificationService)
        {
            _EntradasSaidasService = entradasSaidasService;
            _NotificationService = notificationService;
        }

        // GET: Guarita/Saidas
        public ActionResult Index()
        {
            return View(_EntradasSaidasService.GetSaidas());
        }

        // GET: Guarita/Saidas/Details/5
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

        // GET: Guarita/Saidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guarita/Saidas/Create
        [HttpPost]
        public ActionResult Create(EntradasSaidasDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.EntradaId != null)
                    {
                        if(!(_EntradasSaidasService.FilterByEntradaId((int)model.EntradaId).Count() > 0))
                        {
                            var entrada = _EntradasSaidasService.FindById((int)model.EntradaId);

                            model.Tipo = Tipo.Saida;

                            model.VisitanteId = entrada.VisitanteId;

                            model.VeiculoId = entrada.VeiculoId;

                            model.Data = DateTime.Now;

                            model.IdUser = User.Identity.GetUserId();

                            _EntradasSaidasService.Add(model);

                            var Role = _Context.Roles.Where(x => x.Name == "Guarita").FirstOrDefault();
                            if(Role != null)
                            {
                                foreach(var user in Role.Users.ToList())
                                {
                                    _NotificationService.Add(NotificationType.SaidaGuarita, user.UserId);
                                }                                
                            }                           

                            return RedirectToAction("Index");
                        }

                        ModelState.AddModelError("EntradaId", "Já possui saida para essa entrada!");
                    }
                    else
                    {
                        ModelState.AddModelError("EntradaId", "Selecione a Entrada!");
                    }            
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
                var saida = _EntradasSaidasService.FindById(id);
                _EntradasSaidasService.Remove(saida);
            }

            return RedirectToAction("Index", "Saidas", new { area = "Guarita" });
        }

        // GET: Guarita/Saidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entradasSaidasDTO = _EntradasSaidasService.FindById((int)id);

            if (entradasSaidasDTO == null)
            {
                return HttpNotFound();
            }

            return View(entradasSaidasDTO);
        }

        // POST: Guarita/Saidas/Edit/5
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

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            _EntradasSaidasService.Dispose();
            _NotificationService.Dispose();
            base.Dispose(disposing);
        }
    }
}
