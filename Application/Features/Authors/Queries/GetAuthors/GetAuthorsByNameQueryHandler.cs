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

namespace Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsByNameQueryHandler : IRequestHandler<GetAuthorsByNameQuery, GetAuthorsResponse>
    {
        private readonly IAuthorRepository authorRepository;
        private readonly ILogger<GetAuthorsByNameQueryHandler> logger;
        private readonly IMapper mapper;

        public GetAuthorsByNameQueryHandler(IAuthorRepository authorRepository, ILogger<GetAuthorsByNameQueryHandler> logger, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<GetAuthorsResponse> Handle(GetAuthorsByNameQuery request, CancellationToken cancellationToken)
        {
            var getAuthorsResponse = new GetAuthorsResponse();
            var validator = new GetAuthorsByNameValidator();

            try
            {
                var resultValidation = await validator.ValidateAsync(request, cancellationToken);
                if(resultValidation.Errors.Count > 0)
                {
                    foreach( var error in resultValidation.Errors.Select(x => x.ErrorMessage))
                    {
                        getAuthorsResponse.Success = false;
                        getAuthorsResponse.ValidationErrors = new List<string>();
                        logger.LogError($"An error occur --{error}");
                    }
                   
                }
                else if (getAuthorsResponse.Success)
                {
                    var authorsResult = await authorRepository.GetAllAuthorsAsync(request.Name);
                    getAuthorsResponse.Authors = mapper.Map<List<AuthorDto>>(authorsResult);
                }
            }
            catch (Exception ex)
            {

                logger.LogError($"{ex.Message}", ex);   
            }
            return getAuthorsResponse;
        }
    }
}
