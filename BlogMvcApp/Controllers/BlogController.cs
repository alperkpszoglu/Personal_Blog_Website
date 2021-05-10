using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Entity;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
   [Authorize(Roles ="admin")]
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.OrderByDescending(i => i.AddedTime).Include(b => b.Category);
            return View(blogs.ToList());
        }

        [AllowAnonymous]
        public ActionResult List(int? id, string key)
        {
            var blogs = db.Blogs.Where(i => i.Approve == true).Select(i => new BlogModel()
            {
                Id = i.Id,
                Heading = i.Heading.Length > 100 ? i.Heading.Substring(0, 75) + "..." : i.Heading,
                Description = i.Description,
                Image = i.Image,
                AddedTime = i.AddedTime,
                Homepage = i.Homepage,
                Approve = i.Approve,
                CategoryId = i.CategoryId
            }).AsQueryable();

            if (string.IsNullOrEmpty(key) == false)
            {
                blogs = blogs.Where(i => i.Heading.Contains(key) || i.Description.Contains(key));
            }

            if (id != null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }

            return View(blogs.ToList());

        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Heading,Description,Image,Content,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.AddedTime = DateTime.Now;
                //blog.Approve = false;  default

                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Heading,Description,Image,Content,Approve,Homepage,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Heading = blog.Heading;
                    entity.Description = blog.Description;
                    entity.Image = blog.Image;
                    entity.Content = blog.Content; //without addedtime
                    entity.Approve = blog.Approve;
                    entity.Homepage = blog.Homepage;
                    entity.CategoryId = blog.CategoryId;
                }
                db.SaveChanges();
                TempData["UpdatedBlog"] = entity;// we have to use TempData because we'll use RedirecToAction

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
