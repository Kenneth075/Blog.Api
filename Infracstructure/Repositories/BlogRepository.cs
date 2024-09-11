using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class BlogRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogDbContext blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await blogDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? blog = await blogDbContext.Set<T>().FindAsync(id);
            return blog;
        }

        public async Task<T> CreateBlogAsync(T blog)
        {
            await blogDbContext.Set<T>().AddAsync(blog);
            await blogDbContext.SaveChangesAsync();
            return blog;
            
        }

        public async Task UpdateBlogAsync(T blog)
        {
            blogDbContext.Entry(blog).State = EntityState.Modified;
            await blogDbContext.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(T blog)
        {
            blogDbContext.Set<T>().Remove(blog);
            await blogDbContext.SaveChangesAsync();
        }

        
    }
}
