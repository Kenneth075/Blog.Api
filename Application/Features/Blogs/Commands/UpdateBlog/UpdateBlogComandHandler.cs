using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogComandHandler : IRequestHandler<UpdateBlogCommand, UpdateBlogResponse>
    {
        private readonly IRepository<Blog> repository;
        private readonly ILogger<UpdateBlogComandHandler> logger;
        private readonly IMapper mapper;

        public UpdateBlogComandHandler(IRepository<Blog> repository, ILogger<UpdateBlogComandHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<UpdateBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateResponse = new UpdateBlogResponse();
            var validator = new UpdateBlogValidator(repository);

            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    updateResponse.Success = false;
                    updateResponse.ValidationErrors = new List<string>();

                    foreach (var error in validationResult.Errors.Select(x => x.ErrorMessage))
                    {
                        updateResponse.ValidationErrors.Add(error);
                        logger.LogError("Validation fail, an error occur");
                    }
                }
                else if (updateResponse.Success)
                {
                    var blogEntity = await repository.GetByIdAsync(request.Id);
                    mapper.Map(request.UpdateBlog, blogEntity);
                    await repository.UpdateBlogAsync(blogEntity);
                    updateResponse.Blog = mapper.Map<BlogDto>(blogEntity);


                }

            }
            catch (Exception ex)
            {

                logger.LogError($"An error occur {ex.Message}", ex);
                updateResponse.Success = false;
            }

            return updateResponse;
        }
    }
}
