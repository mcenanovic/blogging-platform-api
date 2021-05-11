using BloggingPlatform.Infrastructure.Ef.Entities;
using BloggingPlatform.Infrastructure.Ef.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.EntityTypeConfigurations
{
    internal class PostTagEntityTypeConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTags");

            builder
                .HasKey(x => new { x.PostSlug, x.TagSlug });

            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.PostTags)
                .HasForeignKey(x => x.PostSlug);

            builder
               .HasOne(x => x.Tag)
               .WithMany(x => x.PostTags)
               .HasForeignKey(x => x.TagSlug);

            builder.SeedData();
        }
    }
}
