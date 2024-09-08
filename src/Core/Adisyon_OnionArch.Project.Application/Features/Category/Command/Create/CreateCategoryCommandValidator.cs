using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
