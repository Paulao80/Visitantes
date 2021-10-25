using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Models;
using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
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
    public class MotoristasController : Controller
    {
        private readonly IMotoristaService _MotoristaService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public MotoristasController(IMotoristaService motoristaService)
        {
            _MotoristaService = motoristaService;
        }

        // GET: Transporte/Motoristas
        public ActionResult Index()
        {
            return View(_MotoristaService.GetAll());
        }

        // GET: Transporte/Motoristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MotoristaDTO motorista = _MotoristaService.FindById((int)id);

            if(motorista == null)
            {
                return HttpNotFound();
            }

            ViewBag.Usuario = _Context.Users.Find(motorista.UserId).NomeCompleto;

            return View(motorista);
        }

        // GET: Transporte/Motoristas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Motoristas/Create
        [HttpPost]
        public ActionResult Create(MotoristaDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_MotoristaService.FindByCnhRg(model.CnhRg) == null)
                    {
                        model.UserId = User.Identity.GetUserId();

                        _MotoristaService.Add(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("CnhRg", "Motorista já Cadastrado!");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Transporte/Motoristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MotoristaDTO motorista = _MotoristaService.FindById((int)id);

            if (motorista == null)
            {
                return HttpNotFound();
            }

            ViewBag.Usuario = _Context.Users.Find(motorista.UserId).NomeCompleto;

            return View(motorista);
        }

        // POST: Transporte/Motoristas/Edit/5
        [HttpPost]
        public ActionResult Edit(MotoristaDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var motorista = _MotoristaService.FindByCnhRg(model.CnhRg);

                    if(motorista == null || motorista.MotoristaId == model.MotoristaId)
                    {
                        _MotoristaService.Update(model);

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("CnhRg", "Motorista já Cadastrado!");
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
                var motorista = _MotoristaService.FindById(id);
                _MotoristaService.Remove(motorista);
            }

            return RedirectToAction("Index", "Motoristas", new { area = "Transporte" });
        }

        public JsonResult GetMotoristas()
        {
            return Json(_MotoristaService.GetMotoristaArray());
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            _MotoristaService.Dispose();
            base.Dispose(disposing);
        }
    }
}
