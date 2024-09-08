using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidation : AbstractValidator<GetCategoryByIdQueryRequest>
    {
        public GetCategoryByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
