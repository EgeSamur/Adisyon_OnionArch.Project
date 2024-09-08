using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetAllCategoriesWithPaging
{
    public class GetAllCategoriesWithPagingQueryRequest : IRequest<IList<GetAllCategoriesWithPagingQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
