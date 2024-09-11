using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetBlogById
{
    public class GetByIdValidator : AbstractValidator<GetBlogByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} Cannot be 0");
        }
    }
}
