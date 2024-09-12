using Application.Features.Authors.Queries.GetAuthors;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository) 
        {
            this.authorRepository = authorRepository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<GetAuthorsResponse>> GetAuthorsByName(string name)
        {
            var response = await Mediator.Send(new  GetAuthorsByNameQuery { Name = name });
            return Ok(response);
        }

    }
}
