using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class AuthorRepository : BlogRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BlogDbContext blogDbContext) : base(blogDbContext)
        {
            
        }
        public async Task<List<Author>> GetAllAuthorsAsync(string name)
        {
            var result = await blogDbContext.Authors.Where(x => x.Name.Contains(name.ToUpper())).ToListAsync();
            return result;
        }
    }
}
