using System.Collections.Generic;

namespace BloggingPlatform.Infrastructure.Ef.Entities
{
    internal class Tag
    {
        public string Slug { get; set; }

        public string Name { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
