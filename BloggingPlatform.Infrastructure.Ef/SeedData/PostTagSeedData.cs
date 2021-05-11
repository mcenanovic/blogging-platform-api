using BloggingPlatform.Infrastructure.Ef.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.SeedData
{
    internal static class PostTagSeedData
    {
        public static void SeedData(this EntityTypeBuilder<PostTag> builder)
        {
            builder.HasData(
                new PostTag
                {
                    PostSlug = "augmented-reality-ios-application",
                    TagSlug = "ios"
                },
                new PostTag
                {
                    PostSlug = "augmented-reality-ios-application",
                    TagSlug = "awesome"
                },
                new PostTag
                {
                    PostSlug = "augmented-reality-android-application",
                    TagSlug = "ar"
                }
            );
        }
    }
}
