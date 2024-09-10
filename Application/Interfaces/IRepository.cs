using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateBlogAsync(T blog);
        Task UpdateBlogAsync(T blog);
        Task DeleteBlogAsync(T blog);
    }
}
