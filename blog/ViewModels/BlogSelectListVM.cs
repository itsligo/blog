using blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.ViewModels
{
    public class BlogSelectListVM
    {
        private List<Blog> _blogs;

        [Display(Name = "Blogs")]
        public int SelectedBlogId { get; set; }

        public IEnumerable<SelectListItem> BlogItems
        {
            get
            {
                using (BlogDb db = new BlogDb())
                {
                    _blogs = db.Blogs.ToList();
                }
                return new SelectList(_blogs, "Id", "BlogTitle");
            }
        }
    }
}