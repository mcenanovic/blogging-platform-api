using BloggingPlatform.Infrastructure.Ef.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.SeedData
{
    internal static class TagSeedData
    {
        public static void SeedData(this EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag
                {
                    Slug = "ios",
                    Name = "iOS"
                },
                new Tag
                {
                    Slug = "awesome",
                    Name = "Awesome"
                },
                new Tag
                {
                    Slug = "ar",
                    Name = "AR"
                }
            );
        }
    }
}
