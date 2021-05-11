using BloggingPlatform.Core.Entities;
using BloggingPlatform.Core.Validators;
using BloggingPlatform.Core.Validatorsx;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BloggingPlatform.Core.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddBloggingPlatformCore(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<Tag>, TagValidator>();
        }
    }
}
