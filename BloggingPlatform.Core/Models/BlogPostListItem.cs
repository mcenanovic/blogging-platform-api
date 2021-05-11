using System.Collections.Generic;

namespace BloggingPlatform.Core.Models
{
    public class BlogPostListItem
    {
        public List<BlogPost> BlogPosts { get; set; }

        public int PostsCount { get; set; }
    }
}
