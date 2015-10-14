using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    // Manages details of a single Blog
    public class Blog
    {
        [Display(Name="Title of Blog")]
        public string BlogTitle { get; set; }
        [Display(Name = "Author Name")]
        public string BlogAuthor { get; set; }
        public List<Post> Posts { get; set; }
    }

    // Manages details of a single Post (of a Blog)
    public class Post
    {
        public DateTime PostingDate { get; set; }
        public string PostContent { get; set; }
        public string PostTitle { get; set; }
    }
}