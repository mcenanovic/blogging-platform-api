using BloggingPlatform.Infrastructure.Ef.Entities;
using BloggingPlatform.Infrastructure.Ef.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Ef.EntityTypeConfigurations
{
    internal class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder
                .HasKey(x => x.Slug);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.SeedData();
        }
    }
}
