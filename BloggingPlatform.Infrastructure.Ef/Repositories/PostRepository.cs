using BloggingPlatform.Core;
using BloggingPlatform.Core.Entities;
using BloggingPlatform.Core.Models;
using BloggingPlatform.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Infrastructure.Ef.Repositories
{
    internal class PostRepository : IPostRepository
    {
        private BloggingPlatformDbContext dbContext;
        private ITagRepository tagRepository;

        public PostRepository(BloggingPlatformDbContext dbContext, ITagRepository tagRepository)
        {
            this.dbContext = dbContext;
            this.tagRepository = tagRepository;
        }

        public async Task<BlogPostListItem> GetPostsAsync(string tag)
        {
            var blogPosts = await dbContext.Posts
                .Select(x => new BlogPost
                {
                    Title = x.Title,
                    Description = x.Description,
                    Body = x.Body,
                    TagList = x.PostTags.Select(t => t.Tag.Name).ToList(),
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .OrderByDescending(x => x.UpdatedAt)
                .ToListAsync();

            if (!string.IsNullOrEmpty(tag))
            {
                blogPosts = blogPosts.Where(x => x.TagList.Contains(tag)).ToList();
            }

            return new BlogPostListItem
            {
                BlogPosts = blogPosts,
                PostsCount = blogPosts.Count
            };
        }

        public Task<BlogPostItem> GetPostBySlugAsync(string slug)
        {
            return dbContext.Posts
                .Where(x => x.Slug == slug)
                .Select(x => new BlogPostItem
                {
                    BlogPost = new BlogPost
                    {
                        Title = x.Title,
                        Description = x.Description,
                        Body = x.Body,
                        TagList = x.PostTags.Select(t => t.Tag.Name).ToList(),
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }
                })
                .FirstOrDefaultAsync();
        }

        public Task<string> CreatePostAsync(BlogPostAddItem post)
        {
            return Task.Run(async () =>
            {
                var slug = UtilityService.GenerateSlug(post.BlogPost.Title);

                if (await PostExistsAsync(slug))
                {
                    return null;
                }

                var newPostTags = await AddPostTags(slug, post.BlogPost.TagList);

                var newPost = new Entities.Post
                {
                    Slug = slug,
                    Title = post.BlogPost.Title,
                    Description = post.BlogPost.Description,
                    Body = post.BlogPost.Body,
                    PostTags = newPostTags
                };

                dbContext.Posts.Add(newPost);
                dbContext.SaveChanges();

                return slug;
            });
        }

        public Task UpdatePostAsync(string slug, BlogPostUpdateItem post)
        {
            return Task.Run(() =>
            {
                var oldPost = dbContext.Posts
                    .Include(x => x.PostTags)
                    .FirstOrDefault(x => x.Slug == slug);

                if (oldPost == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(post.BlogPost.Title) || post.BlogPost.Title.Equals(oldPost.Title))
                {
                    oldPost.Description = post.BlogPost.Description ?? oldPost.Description;
                    oldPost.Body = post.BlogPost.Body ?? oldPost.Body;
                    oldPost.UpdatedAt = DateTime.Now;

                    dbContext.Update(oldPost);
                }
                else
                {
                    List<Entities.PostTag> updatedPostTags = new();
                    var newSlug = UtilityService.GenerateSlug(post.BlogPost.Title);
                    
                    foreach (var postTag in oldPost.PostTags)
                    {
                        updatedPostTags.Add(new Entities.PostTag
                        {
                            PostSlug = newSlug,
                            TagSlug = postTag.TagSlug
                        });
                    }

                    var newPost = new Entities.Post
                    {
                        Slug = newSlug,
                        Title = post.BlogPost.Title ?? oldPost.Title,
                        Description = post.BlogPost.Description ?? oldPost.Description,
                        Body = post.BlogPost.Body ?? oldPost.Body,
                        CreatedAt = oldPost.CreatedAt,
                        //UpdatedAt = DateTime.Now,
                        PostTags = updatedPostTags
                    };

                    dbContext.Remove(oldPost);
                    dbContext.Posts.Add(newPost);
                }

                dbContext.SaveChanges();
            });
        }

        public Task DeletePostAsync(string slug)
        {
            return Task.Run(() =>
            {
                var post = dbContext.Posts.FirstOrDefault(x => x.Slug == slug);
                if (post != null)
                {
                    dbContext.Remove(post);
                    dbContext.SaveChangesAsync();
                }
            });
        }

        public Task<bool> PostExistsAsync(string slug)
        {
            return dbContext.Posts.AnyAsync(x => x.Slug == slug);
        }

        private Task<List<Entities.PostTag>> AddPostTags(string postSlug, List<string> tagList)
        {
            return Task.Run(async () =>
            {
                var tagSlugs = await tagRepository.CreateTagsAsync(tagList);

                List<Entities.PostTag> newPostTags = new();

                foreach (var tagSlug in tagSlugs)
                {
                    newPostTags.Add(new Entities.PostTag
                    {
                        PostSlug = postSlug,
                        TagSlug = tagSlug
                    });
                }

                return newPostTags;
            });
        }
    }
}
