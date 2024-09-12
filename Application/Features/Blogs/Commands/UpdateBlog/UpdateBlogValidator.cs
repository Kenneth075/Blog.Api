using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> repository;

        public UpdateBlogValidator(IRepository<Blog> repository)
        {
            this.repository = repository;

            RuleFor(x => x.UpdateBlog.Name).NotEmpty().NotNull()
                .WithMessage("{PropertyName} should have a value");

            RuleFor(x => x.UpdateBlog.Description).NotEmpty().NotNull()
                .WithMessage("{PropertyName} should have a value");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} Cannot be 0");

            RuleFor(x => x.Id).MustAsync(IsExistingBlog)
                .WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> IsExistingBlog(int id, CancellationToken cancellationToken)
        {
            var existingBlog = await repository.GetByIdAsync(id).ConfigureAwait(false);
            return existingBlog?.Id > 0;
        }
    }
}
