using blog.Models;
using blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            bvm.Blogs = db.Blogs.ToList();
            bvm.NumberOfBlogs = bvm.Blogs.Count();
            bvm.PostCount = 0;
            bvm.Blogs.ForEach(blg => bvm.PostCount += blg.Posts.Count());
            ViewBag.Title = "Blog List ("+bvm.NumberOfBlogs+")";
            return View(bvm);
        }

        public ActionResult Details(int id)
        {
            // look up Blog matching id
            //Blog foundBlog = db.Blogs.Where(blg => blg.Id == id).FirstOrDefault();
            Blog foundBlog = db.Blogs.Find(id);
            // consider if couldn't be found
            ViewBag.Title = (foundBlog!= null)?"Details of "+foundBlog.BlogTitle:"Could not find blog...";
            return View(foundBlog);
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