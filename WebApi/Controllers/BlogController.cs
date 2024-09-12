using Application.Features;
using Application.Features.Commands.CreateBlog;
using Application.Features.Commands.DeleteBlog;
using Application.Features.Commands.UpdateBlog;
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

        [HttpPost]
        public async Task<ActionResult<CreateBlogResponse>> CreateBlog(CreateBlogRequestDto blog)
        {
            var reponse = await Mediator.Send(new CreateBlogCommand() { Blog = blog});
            return Ok(reponse);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateBlogResponse>> UpdateBlog(int id, UpdateBlogRequestDto blog)
        {
            var response = await Mediator.Send(new UpdateBlogCommand() { Id = id, UpdateBlog = blog });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteBlogResponse>> DeleteBlog(int id)
        {
            var response = await Mediator.Send(new  DeleteBlogCommand() { Id = id });
            return Ok(response);
        }
    }
}
