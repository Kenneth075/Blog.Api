﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<CreateBlogResponse>
    {
        public CreateBlogRequestDto Blog { get; set; }
    }
}
