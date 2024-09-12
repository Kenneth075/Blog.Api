using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
