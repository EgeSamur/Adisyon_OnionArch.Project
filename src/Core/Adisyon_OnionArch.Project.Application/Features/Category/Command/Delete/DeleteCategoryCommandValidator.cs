using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
