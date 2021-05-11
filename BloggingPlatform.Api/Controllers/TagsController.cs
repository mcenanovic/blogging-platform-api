using BloggingPlatform.Core.Models;
using BloggingPlatform.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BloggingPlatform.Api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private ITagRepository tagRepository;
        
        public TagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<TagListItem> Get()
        {
            return await tagRepository.GetTagsAsync();
        }
    }
}
