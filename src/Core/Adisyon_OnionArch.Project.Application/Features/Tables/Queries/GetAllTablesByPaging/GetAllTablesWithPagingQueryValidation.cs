using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging
{
    public class GetAllTablesWithPagingQueryValidation : AbstractValidator<GetAllTablesByPagingQueryRequest>
    {
        public GetAllTablesWithPagingQueryValidation()
        {
            RuleFor(x => x.CurrentPage).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
