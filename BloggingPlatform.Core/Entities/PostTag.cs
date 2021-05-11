namespace BloggingPlatform.Core.Entities
{
    public class PostTag
    {
        public string PostSlug { get; set; }
        public Post Post { get; set; }

        public string TagSlug { get; set; }
        public Tag Tag { get; set; }
    }
}
