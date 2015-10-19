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
        BlogViewModel bvm = new BlogViewModel();    // a BlogViewModel object created to front 'database'

        public HomeController()     // initialise POCO 'database' here so available throughout class
        {   // create some Blog objects
            bvm.Blogs = new List<Blog>()
                { new Blog() { BlogTitle="Ode To Code", BlogAuthor="Scott Allen" },
                    new Blog() { BlogTitle="Hanselman Minutes", BlogAuthor="Scott Hanselman" } };
            bvm.NumberOfBlogs = bvm.Blogs.Count;
            db.Blogs.Add(new Blog() { BlogTitle = "Ode To Code", BlogAuthor = "Scott Allen" });
            db.Blogs.Add(new Blog() { BlogTitle = "Hanselman Minutes", BlogAuthor = "Scott Hanselman" });
            db.SaveChanges();   // persist data to storage
        }

        public ActionResult Index()
        {
            bvm.Blogs = db.Blogs.ToList();
            bvm.NumberOfBlogs = bvm.Blogs.Count();
            ViewBag.Title = "Blog List ("+bvm.NumberOfBlogs+")";
            return View(bvm);
        }

        public ActionResult Details(string id)
        {
            // look up Blog matching id
            Blog foundBlog = bvm.Blogs.Where(blg => blg.BlogTitle == id).FirstOrDefault();
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