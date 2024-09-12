using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Queries.GetBlogs
{
    public class GetsBlogsValidator : AbstractValidator<GetBlogsQuery>
    {
        public GetsBlogsValidator()
        {

        }
    }
}
