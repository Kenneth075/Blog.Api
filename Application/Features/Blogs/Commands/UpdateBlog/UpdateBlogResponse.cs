using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogResponse : BaseResponse
    {
        public BlogDto Blog { get; set; }
    }
}
