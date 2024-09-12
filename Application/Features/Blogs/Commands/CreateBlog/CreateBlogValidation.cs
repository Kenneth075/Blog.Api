using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogValidation : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogValidation()
        {
            RuleFor(x => x.Blog.Name).NotEmpty().NotNull()
                .WithMessage("{PropertyName} should have a value");

            RuleFor(x => x.Blog.Description).NotEmpty().NotNull()
                .WithMessage("{PropertyName} should have a value");
        }
    }
}
