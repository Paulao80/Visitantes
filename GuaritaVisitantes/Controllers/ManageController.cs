using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GuaritaVisitantes.Models;
using System.IO;
using GuaritaVisitantes.Services.Interfaces;
using GuaritaVisitantes.DTO.Models.Enums;

namespace GuaritaVisitantes.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context = new ApplicationDbContext();
        private readonly INotificationService _NotificationService;

        public ManageController(INotificationService notificationService)
        {
            _NotificationService = notificationService;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, INotificationService notificationService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _NotificationService = notificationService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Sua senha foi Alterada."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : message == ManageMessageId.ChangePhoto ? "Sua Foto foi Alterada."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                _NotificationService.Add(NotificationType.TrocaSenha, user.Id);

                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
            //Users = "paulo.ti@tradicaoalimentos.com"
            //Users = "pauloviniciusjipa@gmail.com"
            //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
            //, Roles = "Administrador, Desenvolvedor"
        )]
        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
            //Users = "paulo.ti@tradicaoalimentos.com"
            //Users = "pauloviniciusjipa@gmail.com"
            //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
            //, Roles = "Administrador, Desenvolvedor"
        )]
        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {          
                var token = UserManager.GeneratePasswordResetTokenAsync(model.UserId).Result;
                //var result = await UserManager.AddPasswordAsync(model.UserId, model.NewPassword);
                var result = await UserManager.ResetPasswordAsync(model.UserId, token, model.NewPassword);
                if (result.Succeeded)
                {
                    _NotificationService.Add(NotificationType.TrocaSenha, model.UserId);

                    //var user = await UserManager.FindByIdAsync(model.UserId);
                    //if (user != null)
                    //{
                    //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    //}
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePhoto()
        {
            string IdUser = User.Identity.GetUserId();
            var usuario = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Users.FirstOrDefault(x => x.Id == IdUser);

            string path = Path.Combine(Server.MapPath("~/Users/Imagens"), IdUser);

            if (System.IO.File.Exists(path + ".jpg"))
            {
                ViewBag.Foto = "data:image/jpg;base64," + Convert.ToBase64String(FileToByteArray(path + ".jpg"));
            }
            else if (System.IO.File.Exists(path + ".jpeg"))
            {
                ViewBag.Foto = "data:image/jpeg;base64," + Convert.ToBase64String(FileToByteArray(path + ".jpeg"));
            }
            else if (System.IO.File.Exists(path + ".png"))
            {
                ViewBag.Foto = "data:image/png;base64," + Convert.ToBase64String(FileToByteArray(path + ".png"));
            }
            else
            {
                ViewBag.Foto = null;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePhoto(ChangePhotoViewModel model)
        {
            string IdUser = User.Identity.GetUserId();
            string path = Path.Combine(Server.MapPath("~/Users/Imagens"), IdUser);

            if (!(model.Foto == null))
            {
                if (System.IO.File.Exists(path + ".jpg"))
                {
                    System.IO.File.Delete(path + ".jpg");
                }
                else if (System.IO.File.Exists(path + ".jpeg"))
                {
                    System.IO.File.Delete(path + ".jpeg");
                }
                else if (System.IO.File.Exists(path + ".png"))
                {
                    System.IO.File.Delete(path + ".png");
                }

                model.Foto.SaveAs(Path.Combine(Server.MapPath("~/Users/Imagens"), IdUser + Path.GetExtension(model.Foto.FileName)));
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = System.IO.File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }

        public JsonResult GetUsers()
        {
            var usuarios = context.Users
                .Select(x => new
                {
                    id = x.Id,
                    text = x.NomeCompleto
                })
            .ToArray();

            return Json(usuarios);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            context.Dispose();

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error,
            ChangePhoto
        }

#endregion
    }
}