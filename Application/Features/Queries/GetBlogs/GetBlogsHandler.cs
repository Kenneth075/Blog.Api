using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetBlogs
{
    public class GetBlogsHandler : IRequestHandler<GetBlogsQuery, GetBlogsResponse>
    {
        private readonly IRepository<Blog> repository;
        private readonly ILogger<GetBlogsHandler> logger;
        private readonly IMapper mapper;

        public GetBlogsHandler(IRepository<Blog> repository, ILogger<GetBlogsHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<GetBlogsResponse> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var getBlogsResponse = new GetBlogsResponse();
            var validator = new GetsBlogsValidator();

            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if(validationResult.Errors.Count > 0)
                {
                    getBlogsResponse.Success = false;
                    getBlogsResponse.ValidationErrors = new List<string>();

                    foreach(var error in validationResult.Errors.Select(x => x.ErrorMessage))
                    {
                        getBlogsResponse.ValidationErrors.Add(error);
                        logger.LogError($"Validation fail, an error occur {error}");
                    }
                }
                else if(getBlogsResponse.Success)
                {
                    var result = await repository.GetAllAsync();
                    getBlogsResponse.Blogs = mapper.Map<List<BlogDto>>(result);
                }
                

            }
            catch (Exception ex)
            {
                logger.LogError($"An error occur {ex.Message}", ex);
                getBlogsResponse.Success = false;
            }

            return getBlogsResponse;
        }
    }
}
