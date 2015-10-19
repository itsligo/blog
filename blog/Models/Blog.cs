using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace blog.Models
{
    // Manages details of a single Blog
    public class Blog
    {
        public int Id { get; set; }     // primary key in the resultant db
        [Display(Name="Title of Blog")]
        public string BlogTitle { get; set; }
        [Display(Name = "Author Name")]
        public string BlogAuthor { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    // Manages details of a single Post (of a Blog)
    public class Post
    {
        public int Id { get; set; }     // primary key
        public DateTime PostingDate { get; set; }
        public string PostContent { get; set; }
        public string PostTitle { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BlogDb: DbContext
    {
        public BlogDb():base("BlogDb")
        {}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}