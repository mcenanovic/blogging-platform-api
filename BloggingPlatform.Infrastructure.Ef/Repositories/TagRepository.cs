using BloggingPlatform.Core;
using BloggingPlatform.Core.Models;
using BloggingPlatform.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.Infrastructure.Ef.Repositories
{
    internal class TagRepository : ITagRepository
    {
        private BloggingPlatformDbContext dbContext;

        public TagRepository(BloggingPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<TagListItem> GetTagsAsync()
        {
            return Task.Run(() =>
            {
                var tags = dbContext.Tags.Select(x => x.Name).ToList();

                return new TagListItem
                {
                    Tags = tags
                };
            });
        }

        public Task<List<string>> CreateTagsAsync(List<string> tagList)
        {
            return Task.Run(() =>
            {
                List<Entities.Tag> newTags = new();

                foreach (var tagName in tagList)
                {
                    var tag = dbContext.Tags.FirstOrDefault(x => x.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Entities.Tag
                        {
                            Slug = UtilityService.GenerateSlug(tagName),
                            Name = tagName
                        };

                        dbContext.Tags.Add(tag);
                    }

                    newTags.Add(tag);
                }

                dbContext.SaveChanges();

                return newTags.Select(x => x.Slug).ToList();
            });
        }
    }
}
