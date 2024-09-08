using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
