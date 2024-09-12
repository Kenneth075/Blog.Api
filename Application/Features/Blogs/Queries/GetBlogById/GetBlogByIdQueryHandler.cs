using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdResponse>
    {
        private readonly IRepository<Blog> repository;
        private readonly ILogger<GetBlogByIdQueryHandler> logger;
        private readonly IMapper mapper;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository, ILogger<GetBlogByIdQueryHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<GetBlogByIdResponse> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var getBlogResponse = new GetBlogByIdResponse();
            var validator = new GetByIdValidator();

            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    getBlogResponse.Success = false;
                    getBlogResponse.ValidationErrors = new List<string>();

                    foreach (var error in validationResult.Errors.Select(x => x.ErrorMessage))
                    {
                        getBlogResponse.ValidationErrors.Add(error);
                        logger.LogError($"Validation fail, an error occur {error}");
                    }
                }
                else if (getBlogResponse.Success)
                {
                    var result = await repository.GetByIdAsync(request.Id);
                    getBlogResponse.Blog = mapper.Map<BlogDto>(result);
                }


            }
            catch (Exception ex)
            {
                logger.LogError($"An error occur {ex.Message}", ex);
                getBlogResponse.Success = false;
            }

            return getBlogResponse;
        }
    }
}
