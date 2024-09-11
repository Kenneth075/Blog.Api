using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.SeedData
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(BlogDbContext dbContext)
        {
            if(!dbContext.Blogs.Any())
            {
                var blogs = new Blog[]
                {
                    new Blog
                    {
                        Name = "VV blog",
                        Description = "Lagos number 1 blog"
                    },
                    new Blog
                    {
                        Name = "Ik blog",
                        Description = "Nigeria most up to date blog"
                    }

                };

                dbContext.Blogs.AddRange(blogs);
                dbContext.SaveChanges();
            }

           

            if (!dbContext.Authors.Any())
            {
                var authors = new Author[]
                {
                    new Author
                    {
                        Name = "Hanks Anku",
                        Email = "Ankus@gmail.com"
                    },
                    new Author
                    {
                        Name = "Kenneth Edoho",
                        Email = "kenny@gmail.com"
                    }
                };
                dbContext.Authors.AddRange(authors);
                dbContext.SaveChanges();
            }
        }
    }
}
