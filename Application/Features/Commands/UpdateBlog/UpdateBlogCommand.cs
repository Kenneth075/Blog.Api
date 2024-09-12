using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateBlog
{
    public class UpdateBlogCommand : BaseDto, IRequest<UpdateBlogResponse>
    {
        public UpdateBlogRequestDto UpdateBlog { get; set; }
    }
}
