﻿using System;
using System.Collections.Generic;

namespace BloggingPlatform.Core.Models
{
    public class BlogPost
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public List<string> TagList { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
