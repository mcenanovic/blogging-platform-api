using BloggingPlatform.Infrastructure.Ef.Entities;
using BloggingPlatform.Infrastructure.Ef.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Ef
{
    internal class BloggingPlatformDbContext : DbContext
    {
        public BloggingPlatformDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagEntityTypeConfiguration());
        }
    }
}
