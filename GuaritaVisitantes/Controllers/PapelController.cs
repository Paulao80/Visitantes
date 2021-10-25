using GuaritaVisitantes.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GuaritaVisitantes.Controllers
{
    public class PapelController : Controller
    {

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
            //Users = "paulo.ti@tradicaoalimentos.com"
            //Users = "pauloviniciusjipa@gmail.com"
            //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
            //, Roles = "Administrador, Desenvolvedor"
        )]
        //GET: Papel
        public ActionResult Index()
        {
            // Populate Dropdown Lists
            var context = new ApplicationDbContext();

            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            ViewBag.Message = "";

            return View();
        }

        [Authorize]
        public ActionResult NoAuthorize()
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
        public ActionResult Edit(string roleName)
        {
            var context = new ApplicationDbContext();
            var thisRole = context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

            return View(thisRole);
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
        )]
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                var context = new ApplicationDbContext();
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
            //Users = "paulo.ti@tradicaoalimentos.com"
            //Users = "pauloviniciusjipa@gmail.com"
            //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
            //, Roles = "Administrador, Desenvolvedor"
        )]
        public ActionResult Delete (string RoleName)
        {  

            try
            {
                var context = new ApplicationDbContext();

                var role = context.Roles.FirstOrDefault(u => u.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase));

                var roleStore = new RoleStore<IdentityRole>(context);

                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Delete(role);

                var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = rolelist;

                var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
                ViewBag.Users = userlist;

                ViewBag.Message = "Papel removido com sucesso!";

                context.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Message = "Erro ao remover o papel: "+e.Message;
            }

            return View("Index");
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
            //Users = "paulo.ti@tradicaoalimentos.com"
            //Users = "pauloviniciusjipa@gmail.com"
            //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
            //, Roles = "Administrador, Desenvolvedor"
        )]
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var context = new ApplicationDbContext();
                context.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.Message = "Papel criado com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
        )]
        //  Adding Roles to a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string userName, string roleName)
        {
            var context = new ApplicationDbContext();

            if (context == null)
            {
                //throw new ArgumentNullException("context", "O Contexto não deve ser nulo.");
                throw new ArgumentNullException("context", "O Contexto não deve ser nulo.");
            }

            //ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var user = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(user?.Id, roleName);


            ViewBag.Message = "Papel criado com successo!";

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
        )]
        //Getting a List of Roles for a User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return View("Index");

            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ViewBag.RolesForThisUser = userManager.GetRoles(user?.Id);


            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;
            ViewBag.Message = "Papel recuperado com successo!";

            return View("Index");
        }

        [Authorize(
            Roles = "Administrador, Analista, Desenvolvedor"
        //Users = "paulo.ti@tradicaoalimentos.com"
        //Users = "pauloviniciusjipa@gmail.com"
        //, Users = "natael.ti@tradicaoalimentos.com, gerencia.ti@tradicaoalimentos.com"
        //, Roles = "Administrador, Desenvolvedor"
        )]
        //Deleting a User from A Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {
            //var account = new AccountController();
            var context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            if (userManager.IsInRole(user?.Id, roleName))
            {
                userManager.RemoveFromRole(user?.Id, roleName);
                ViewBag.Message = "Papel removido deste usuário com successo!";
            }
            else
            {
                ViewBag.Message = "Este usuário não pertence ao papel selecionado.";
            }

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }
    }
}