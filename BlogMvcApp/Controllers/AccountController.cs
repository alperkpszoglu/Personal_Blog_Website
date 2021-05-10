using BlogMvcApp.Identity;
using BlogMvcApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController()
        {
            var userStore = new UserStore<IdentityUser>(new IdentityDataContext());
            userManager = new UserManager<IdentityUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(new IdentityDataContext());
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                { 
                    if (roleManager.RoleExists("user"))
                    {
                        userManager.AddToRole(user.Id,"user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterCreateError", "Kullanıcı oluşturma hatası");
                }
            }
            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Erişim Hakkınız yok." });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);

                if (user!=null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); //cookie

                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = model.RememberMe; //is it persistent???

                    authManager.SignOut();
                    authManager.SignIn(authProperties,identityclaims);

                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("UserNotFound", "Böyle Bir Kullanıcı Yok"); //this is gonna go validationsummary
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [Authorize]
       public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }
    }
}