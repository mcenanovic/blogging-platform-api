using System;
using System.Collections.Generic;

namespace BloggingPlatform.Infrastructure.Ef.Entities
{
    internal class Post
    {
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
