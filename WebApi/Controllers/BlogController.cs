using Application.Features.Queries.GetBlogById;
using Application.Features.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        public BlogController()
        {
            
        }

        [HttpGet]
        public async Task<ActionResult<GetBlogsResponse>> GetBlogsAsync()
        {
            var result = await Mediator.Send(new GetBlogsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBlogByIdResponse>> GetBlogById(int id)
        {
            var response = await Mediator.Send(new GetBlogByIdQuery() {Id = id});
            if (response.Blog == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
