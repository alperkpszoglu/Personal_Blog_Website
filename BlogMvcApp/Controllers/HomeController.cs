using BlogMvcApp.Entity;
using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var blogs = context.Blogs.Where(i => i.Approve == true && i.Homepage == true).ToList()
            .Select(i => new BlogModel()
            {
                Id = i.Id,
                Heading = i.Heading.Length > 100 ? i.Heading.Substring(0, 75) + "..." : i.Heading,
                Description = i.Description,
                Image = i.Image,
                AddedTime = i.AddedTime,
                Homepage = i.Homepage,
                Approve = i.Approve
            });

            return View(blogs);
        }

    }
}