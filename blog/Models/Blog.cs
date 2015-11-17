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
        [Display(Name="Title")]
        public string BlogTitle { get; set; }
        [Display(Name = "Author")]
        public string BlogAuthor { get; set; }
        // navigation property to constituent Post objects - inferred as relationships implemented by foreign keys in SQL
        public virtual ICollection<Post> Posts { get; set; }
    }

    // Manages details of a single Post (of a Blog)
    public class Post
    {
        public int Id { get; set; }     // primary key
        [Display(Name = "Post Date")]
        public DateTime PostingDate { get; set; }
        [Display(Name = "Post Content")]
        public string PostContent { get; set; }
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }
        // Navigation prop to associated Blog - becomes foreign key in Posts table
        public virtual Blog Blog { get; set; }
    }

    public class BlogDb: DbContext
    {
        // Pass Name of connection string found in web.config
        // Defaults to name of DbContext class
        public BlogDb():base("BlogDb")
        {}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}