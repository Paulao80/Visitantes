using GuaritaVisitantes.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace GuaritaVisitantes.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _NotificationService;

        public NotificationController(INotificationService notificationService)
        {
            _NotificationService = notificationService;
        }

        // GET: Notification
        [HttpGet]
        public JsonResult Index()
        {
            return Json(_NotificationService.GetNotificationByUserIdArray(User.Identity.GetUserId()), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Read(int Key)
        {
            try
            {      
                _NotificationService.Update(Key,true);

                return Json(new { Sucess = true, Response = "OK" });
            }
            catch(Exception e)
            {
                return Json(new { Sucess = false, Response = e.Message });
            }      
        }

        protected override void Dispose(bool disposing)
        {
            _NotificationService.Dispose();
            base.Dispose(disposing);
        }
    }
}