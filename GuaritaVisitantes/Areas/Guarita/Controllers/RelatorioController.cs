using GuaritaVisitantes.Services.Interfaces;
using System;
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
    public class RelatorioController : Controller
    {
        private readonly IReportService _ReportService;
        private static byte[] arquivo;

        public RelatorioController(IReportService reportService)
        {
            _ReportService = reportService;
        }

        // GET: Guarita/Relatorio
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DateTime? DateIni, DateTime? DateEnd, int? Tipo)
        {
            if(DateIni != null && DateEnd != null && Tipo != null)
            {

                var dtEnd = ((DateTime)DateEnd).AddHours(23).AddMinutes(59).AddSeconds(59);      

                if (Tipo == 0)
                {
                    arquivo = _ReportService.GerarEntradaGuarita((DateTime)DateIni, dtEnd).ToArray();
                    return RedirectToAction("Exibir");
                }
                else if (Tipo == 1)
                {
                    arquivo = _ReportService.GerarSaidaGuarita((DateTime)DateIni, dtEnd).ToArray();
                    return RedirectToAction("Exibir");
                }
                else if(Tipo == 2)
                {
                    arquivo = _ReportService.GerarAllGuarita((DateTime)DateIni, dtEnd).ToArray();
                    return RedirectToAction("Exibir");
                }
            }

            ModelState.AddModelError("Erro", "Preencher todos os campos!");

            return View();
        }

        public ActionResult Exibir()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", arquivo.Length.ToString());
            Response.BinaryWrite(arquivo);         
            Response.End();
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _ReportService.Dispose();
            base.Dispose(disposing);
        }
    }
}