using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : BaseDto, IRequest<GetBlogByIdResponse>
    {
    }
}
