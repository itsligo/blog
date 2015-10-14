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
        public ActionResult Index()
        {
            // Retrieve (database?) or fashion some Blog entities/objects
            // No database? So, make in-memory (or POCO) objects instead & populate ViewModel
            var bvm = new BlogViewModel();    // a BlogViewModel object created
            bvm.Blogs = new List<Blog>()
                { new Blog() { BlogTitle="Ode To Code", BlogAuthor="Scott Allen" },
                    new Blog() { BlogTitle="Hanselman Minutes", BlogAuthor="Scott Hanselman" } };
            bvm.NumberOfBlogs = bvm.Blogs.Count;
            ViewBag.Title = "Blog List";
            return View(bvm);
        }

        public ActionResult Details(string id)
        {
            // recreate 'database' mockup for expediency
            var bvm = new BlogViewModel();    // a BlogViewModel object created
            bvm.Blogs = new List<Blog>()
                { new Blog() { BlogTitle="Ode To Code", BlogAuthor="Scott Allen" },
                    new Blog() { BlogTitle="Hanselman Minutes", BlogAuthor="Scott Hanselman" } };
            bvm.NumberOfBlogs = bvm.Blogs.Count;
            // look up Blog matching id
            Blog foundBlog = bvm.Blogs.Where(blg => blg.BlogTitle == id).FirstOrDefault();
            ViewBag.Title = "Details of ";
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