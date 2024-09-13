using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorValidation : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidation()
        {
            RuleFor(x => x.CreateAuthorRequestDto.Name).NotEmpty().NotNull()
                .WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.CreateAuthorRequestDto.Email).NotEmpty().NotNull()
                .WithMessage("{PropertyName} cannot be null");
        }
    }
}
