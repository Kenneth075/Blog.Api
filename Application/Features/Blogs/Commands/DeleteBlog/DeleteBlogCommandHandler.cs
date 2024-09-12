using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, DeleteBlogResponse>
    {
        private readonly IRepository<Blog> repository;
        private readonly ILogger<DeleteBlogCommandHandler> logger;
        private readonly IMapper mapper;

        public DeleteBlogCommandHandler(IRepository<Blog> repository, ILogger<DeleteBlogCommandHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<DeleteBlogResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var deleteResponse = new DeleteBlogResponse();
            var validator = new DeleteBlogValidator(repository);

            try
            {
                var deleteResultValidation = await validator.ValidateAsync(request, cancellationToken);
                if (deleteResultValidation.Errors.Count > 0)
                {
                    deleteResponse.Success = false;
                    deleteResponse.ValidationErrors = new List<string>();

                    foreach (var error in deleteResultValidation.Errors.Select(x => x.ErrorMessage))
                    {
                        deleteResponse.ValidationErrors.Add(error);
                        logger.LogError("Validation fail, an error occur");
                    }
                }
                else if (deleteResponse.Success)
                {
                    var existingBlog = await repository.GetByIdAsync(request.Id);
                    await repository.DeleteBlogAsync(existingBlog);
                    deleteResponse.Blog = mapper.Map<BlogDto>(existingBlog);
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"An error occur {ex.Message}", ex);
                deleteResponse.Success = false;
            }

            return deleteResponse;
        }
    }
}
