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

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorReponse>
    {
        private readonly IAuthorRepository authorRepository;
        private readonly ILogger<CreateAuthorCommandHandler> logger;
        private readonly IMapper mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<CreateAuthorCommandHandler>logger, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<CreateAuthorReponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var createResponse = new CreateAuthorReponse();
            var validator = new CreateAuthorValidation();

            try
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if(validationResult.Errors.Count > 0)
                {
                    createResponse.Success = false;
                    createResponse.ValidationErrors = new List<string>();

                    foreach (var error in validationResult.Errors.Select(x => x.ErrorMessage))
                    {
                        createResponse.ValidationErrors.Add(error);
                        logger.LogError($"An error occur --{error}");
                    }
                    
                }
                else if(createResponse.Success)
                {
                    var authorRequestDto = mapper.Map<Author>(request.CreateAuthorRequestDto);
                    await authorRepository.CreateAuthorAsync(authorRequestDto);
                    createResponse.Author = mapper.Map<AuthorDto>(authorRequestDto);
                }

            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message );
            }
            return createResponse;
        }
    }
}
