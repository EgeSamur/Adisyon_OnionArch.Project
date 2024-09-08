using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetAllCategoriesWithPaging
{
    public class GetAllCategoriesWithPagingQueryValidation : AbstractValidator<GetAllCategoriesWithPagingQueryRequest>
    {
        public GetAllCategoriesWithPagingQueryValidation()
        {
            RuleFor(x=>x.CurrentPage).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
