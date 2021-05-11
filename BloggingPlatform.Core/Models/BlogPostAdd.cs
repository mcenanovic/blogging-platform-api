using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggingPlatform.Core.Models
{
    public class BlogPostAdd
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }

        public List<string> TagList { get; set; }
    }
}
