using System;
using EFCoreDemo.Models;

namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create
                // Console.WriteLine("Creating a new blog.");
                // db.Add(new Blog
                // {
                //     Url = "https://www.myblogs.com/blogOne"
                // });
                // db.SaveChanges();

                Console.WriteLine("Creating a new post.");
                db.Add(new Post
                {
                    Title = "New Post 2",
                    Content = "This is my first post 3",
                    BlogId = 2,
                    Blog = new Blog{
                        Url = "https://www.myblogs.com/secondblog"
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
