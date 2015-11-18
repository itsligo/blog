using blog.Models;
using blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        public BlogDb db = new BlogDb();    // our database
        BlogViewModel bvm = new BlogViewModel();    // a BlogViewModel object created to surface database entities

        public ActionResult Index()
        {
            // retreive Blogs from db
            bvm.Blogs = db.Blogs.Include("Posts").ToList();
            bvm.NumberOfBlogs = bvm.Blogs.Count();
            bvm.PostCount = 0;
            bvm.Blogs.ForEach(blg => bvm.PostCount += blg.Posts.Count());
            ViewBag.Title = "Blog List ("+bvm.NumberOfBlogs+")";
            return View(bvm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            // look up Blog matching id
            //Blog foundBlog = db.Blogs.Where(blg => blg.Id == id).FirstOrDefault();
            Blog foundBlog = db.Blogs.Find(id);
            // if not found
            if (foundBlog == null) return HttpNotFound();
            ViewBag.Title = "Details of "+foundBlog.BlogTitle;
            return View(foundBlog);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog blg)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blg);
        }

        [HttpGet]
        public ActionResult Delete(int? blgId)
        {
            if (blgId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(blgId);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int blgId)
        {
            Blog blg = db.Blogs.Find(blgId);
            var postsToDelete = blg.Posts.ToList();
            foreach (var item in postsToDelete)
            {
                db.Posts.Remove(item);
            }

            db.Blogs.Remove(blg);
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}