using BloggingPlatform.Core.Entities;
using BloggingPlatform.Core.Models;
using System.Threading.Tasks;

namespace BloggingPlatform.Core.Repositories
{
    public interface IPostRepository
    {
        Task<BlogPostListItem> GetPostsAsync(string tag);

        Task<BlogPostItem> GetPostBySlugAsync(string slug);

        Task<string> CreatePostAsync(BlogPostAddItem post);

        Task UpdatePostAsync(string slug, BlogPostUpdateItem post);

        Task DeletePostAsync(string slug);

        Task<bool> PostExistsAsync(string slug);
    }
}
