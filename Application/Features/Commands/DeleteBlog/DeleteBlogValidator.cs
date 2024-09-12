using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteBlog
{
    public class DeleteBlogValidator : AbstractValidator<DeleteBlogCommand>
    {
        private readonly Interfaces.IRepository<Blog> repository;

        public DeleteBlogValidator(IRepository<Blog> repository)
        {
            this.repository = repository;

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} Cannot be 0");
            RuleFor(x => x.Id).MustAsync(IsExistingBlog).WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> IsExistingBlog(int id, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(id).ConfigureAwait(false);
            return result?.Id > 0;

        }
    }
}
