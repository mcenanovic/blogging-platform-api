using BloggingPlatform.Core.Entities;
using FluentValidation;

namespace BloggingPlatform.Core.Validatorsx
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Slug).NotEmpty().WithMessage("Slug is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
