using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : BaseDto, IRequest<DeleteBlogResponse>
    {
        //public DeleteRequestDto requestDto { get; set; }
    }
}
