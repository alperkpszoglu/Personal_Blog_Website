using BlogMvcApp.Identity;
using BlogMvcApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityExample.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;

        public AdminController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDataContext()));
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDataContext()));
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public ActionResult Edit(string id)
        {
            var role = roleManager.FindById(id);

            var users = new List<IdentityUser>();
            var nonUsers = new List<IdentityUser>();

            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, role.Name) ? users : nonUsers;

                list.Add(user);
            }

            return View(new RoleEditModel()
            {
                Users = users,
                NonUsers = nonUsers,
                Role = role
            });
        }

        [HttpPost]
        public ActionResult Edit(RoleUpdateModel model)
        {
            IdentityResult result; 
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { }) 
                {
                    result = userManager.AddToRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    result = userManager.RemoveFromRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Aranılan rol yok" });
        }
    }
}