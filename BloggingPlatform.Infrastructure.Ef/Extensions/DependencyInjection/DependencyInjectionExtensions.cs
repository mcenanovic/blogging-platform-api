using BloggingPlatform.Core.Repositories;
using BloggingPlatform.Infrastructure.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloggingPlatform.Infrastructure.Ef.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddBloggingPlatformInfrastructureEf(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<BloggingPlatformDbContext>(opt =>
            {
                opt.UseSqlServer(sqlConnectionString);
            });

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
        }
    }
}
