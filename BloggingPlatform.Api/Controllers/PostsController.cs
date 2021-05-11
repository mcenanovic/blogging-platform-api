using BloggingPlatform.Core.Models;
using BloggingPlatform.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet]
        public async Task<BlogPostListItem> Get([FromQuery] string tag)
        {
            return await postRepository.GetPostsAsync(tag);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var post = await postRepository.GetPostBySlugAsync(slug);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogPostAddItem post)
        {
            var slug = await postRepository.CreatePostAsync(post);
            return Created("Get", new { slug });
        }

        [HttpPut("{slug}")]
        public async Task<IActionResult> Put(string slug, [FromBody] BlogPostUpdateItem post)
        {
            if (slug == null || !(await postRepository.PostExistsAsync(slug)))
            {
                return NotFound();
            }

            await postRepository.UpdatePostAsync(slug, post);

            return Ok();
        }

        [HttpDelete("{slug}")]
        public async Task<IActionResult> Delete(string slug)
        {
            if (slug == null || !(await postRepository.PostExistsAsync(slug)))
            {
                return NotFound();
            }

            await postRepository.DeletePostAsync(slug);

            return Ok();
        }
    }
}
