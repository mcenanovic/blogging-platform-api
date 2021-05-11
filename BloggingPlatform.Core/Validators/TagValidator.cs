using BloggingPlatform.Core.Entities;
using FluentValidation;

namespace BloggingPlatform.Core.Validators
{
    class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
