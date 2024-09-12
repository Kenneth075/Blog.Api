using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreateBlogResponse>
    {
        private readonly IRepository<Blog> repository;
        private readonly ILogger<CreateBlogCommandHandler> logger;
        private readonly IMapper mapper;

        public CreateBlogCommandHandler(IRepository<Blog> repository, ILogger<CreateBlogCommandHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<CreateBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var createResponse = new CreateBlogResponse();
            var validator = new CreateBlogValidation();

            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    createResponse.Success = false;
                    createResponse.ValidationErrors = new List<string>();

                    foreach (var error in validationResult.Errors.Select(x => x.ErrorMessage))
                    {
                        createResponse.ValidationErrors.Add(error);
                        logger.LogError("Validation fail, an error occur");
                    }
                }
                else if (createResponse.Success)
                {
                    var createBlog = mapper.Map<Blog>(request.Blog);
                    var result = await repository.CreateBlogAsync(createBlog);
                    createResponse = mapper.Map<CreateBlogResponse>(result);

                }

            }
            catch (Exception ex)
            {

                logger.LogError($"An error occur {ex.Message}", ex);
                createResponse.Success = false;
            }

            return createResponse;
        }
    }
}
