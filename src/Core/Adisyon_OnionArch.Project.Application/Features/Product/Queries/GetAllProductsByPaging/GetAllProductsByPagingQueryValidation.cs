using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetAllProductsByPaging
{
    public class GetAllProductsByPagingQueryValidation : AbstractValidator<GetAllProductsByPagingQueryRequest>
    {
        public GetAllProductsByPagingQueryValidation()
        {
            RuleFor(x=>x.CurrentPage).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.PageSize).GreaterThan(0);
        }
    }
}
