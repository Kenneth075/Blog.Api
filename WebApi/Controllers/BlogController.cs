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
    }
}
