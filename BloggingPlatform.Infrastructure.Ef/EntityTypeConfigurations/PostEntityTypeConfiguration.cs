using BloggingPlatform.Infrastructure.Ef.Entities;
using BloggingPlatform.Infrastructure.Ef.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.EntityTypeConfigurations
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder
                .HasKey(x => x.Slug);

            builder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(x => x.Body);

            builder
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.SeedData();
        }
    }
}
