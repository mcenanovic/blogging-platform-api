using BloggingPlatform.Infrastructure.Ef.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.SeedData
{
    internal static class PostSeedData
    {
        public static void SeedData(this EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    Slug = "augmented-reality-ios-application",
                    Title = "Augmented Reality iOS Application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality iOS app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit."
                },
                new Post
                {
                    Slug = "augmented-reality-web-application",
                    Title = "Augmented Reality Web Application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality Web app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit."
                },
                new Post
                {
                    Slug = "augmented-reality-android-application",
                    Title = "Augmented Reality Android Application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality Android app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit."
                }
            );
        }
    }
}
