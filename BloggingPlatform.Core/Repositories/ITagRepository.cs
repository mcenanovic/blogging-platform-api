using BloggingPlatform.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggingPlatform.Core.Repositories
{
    public interface ITagRepository
    {
        Task<TagListItem> GetTagsAsync();

        Task<List<string>> CreateTagsAsync(List<string> tagList);
    }
}
