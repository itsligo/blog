using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace blog.Models
{
    public class BlogInitialiser:DropCreateDatabaseAlways<BlogDb>
    {
        // Called on database setup
        protected override void Seed(BlogDb context)
        {
            var initBlogs = new List<Blog>
            {
                // neatly nested object creation
                new Blog() { BlogTitle="Ode To Code", BlogAuthor="Scott Allen", Posts = new List<Post> {
                    new Post { PostTitle= "C# Fundamentals with Visual Studio 2015", PostContent="I've created a new C# Fundamentals course with Visual Studio 2015. This course, like the previous course on Pluralsight, doesn't focus so much on syntax and language quirks. Instead,  I like to focus on what I consider the important fundamentals, like understanding the difference between reference types and value types, how types live inside assemblies, some basic design tips, and more.", PostingDate=DateTime.Parse("2015/06/14") },
                    new Post { PostTitle= "JavaScript Promise API", PostContent="A Promise in JavaScript offers a few static methods you can use as convenience methods. For example, when you need to return a promise to a caller but you already have a value ready, the resolve method is handy.", PostingDate=DateTime.Parse("2015/02/4") }
                } },
                new Blog() { BlogTitle="Hanselman Minutes", BlogAuthor="Scott Hanselman", Posts= new List<Post> {
                    new Post { PostTitle= "Integrating Visual Studio Code with dnx-watch to develop ASP.NET 5 applications", PostContent="Visual Studio Code is a great cross platform code editor that is also free. You can get it at code.visualstudio.com for Mac, Windows, or Linux. It's great for web development, and particularly shines with node.js." , PostingDate=DateTime.Parse("2015/04/30")},
                    new Post { PostTitle= "Moving beyond Beginner when 3D Printing and becoming a Handy Person", PostContent="OK, let's just say it. I'm not that handy and I'll never be handy. I'm consistently impressed with all my friends and family members who put up pictures of their amazing dining room tables made from scratch. 'Ya, I raised this tree from a sapling, cut it down, and made this table with tools from the 1700s.'", PostingDate=DateTime.Parse("2014/12/17") }
                } },
                new Blog() { BlogTitle="Coding Horror", BlogAuthor="Jeff Atwood", Posts=new List<Post> {
                    new Post { PostTitle= "Welcome to The Internet of Compromised Things", PostContent="It's becoming more and more common to see malware installed not at the server, desktop, laptop, or smartphone level, but at the router level. Routers have become quite capable, powerful little computers in their own right over the last 5 years, and that means they can, unfortunately, be harnessed to work against you." , PostingDate=DateTime.Parse("2015/01/19")},
                    new Post { PostTitle= "Inside Your Home", PostContent="Buy a new, quality router. You don't want a router that's years old and hasn't been updated. But on the other hand you also don't want something too new that hasn't been vetted for firmware and/or security issues in the real world." , PostingDate=DateTime.Parse("2015/03/1")}
                } }
            };
            initBlogs.ForEach(b => context.Blogs.Add(b));   // delegate to take each Blog and add to db
            context.SaveChanges();  // don't forget to save your stuff
        }
    }
}