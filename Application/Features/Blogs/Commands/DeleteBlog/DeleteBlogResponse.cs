using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogResponse : BaseResponse
    {
        public BlogDto Blog { get; set; }
    }
}
