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
    public class VeiculosController : Controller
    {

        private readonly IVeiculoService _VeiculoService;
        private ApplicationDbContext _Context = new ApplicationDbContext();

        public VeiculosController(IVeiculoService veiculoService)
        {
            _VeiculoService = veiculoService;
        }

        // GET: Transporte/Veiculos
        public ActionResult Index()
        {
            return View(_VeiculoService.GetAll());
        }

        // GET: Transporte/Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VeiculoDTO veiculo = _VeiculoService.FindById((int)id);

            if(veiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.Usuario = _Context.Users.Find(veiculo.UserId).NomeCompleto;

            return View(veiculo);
        }

        // GET: Transporte/Veiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_VeiculoService.FindByPlaca(model.Placa) == null)
                    {
                        model.UserId = User.Identity.GetUserId();

                        _VeiculoService.Add(model);

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

        // GET: Transporte/Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VeiculoDTO veiculo = _VeiculoService.FindById((int)id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);
        }

        // POST: Transporte/Veiculos/Edit/5
        [HttpPost]
        public ActionResult Edit(VeiculoDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veiculo = _VeiculoService.FindByPlaca(model.Placa);
                    if (veiculo == null || veiculo.VeiculoId == model.VeiculoId)
                    {
                        _VeiculoService.Update(model);

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
                var veiculo = _VeiculoService.FindById(id);
                _VeiculoService.Remove(veiculo);
            }

            return RedirectToAction("Index", "Veiculos", new { area = "Transporte" });
        }

        public JsonResult GetVeiculos()
        {
            return Json(_VeiculoService.GetVeiculosArray());
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            _VeiculoService.Dispose();
            base.Dispose(disposing);            
        }
    }
}
