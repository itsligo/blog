using blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.ViewModels
{
    // Summary view for populating the Home/Index View
    // Will need populating with fake data before sending to View
    public class BlogViewModel
    {
        public int NumberOfBlogs { get; set; }
        public List<Blog> Blogs { get; set; }
    }   // end BlogViewModel
}