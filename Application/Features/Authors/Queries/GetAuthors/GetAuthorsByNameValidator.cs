using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsByNameValidator : AbstractValidator<GetAuthorsByNameQuery>
    {
        public GetAuthorsByNameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{Propertyname} cannot be empty");
        }
    }
}
