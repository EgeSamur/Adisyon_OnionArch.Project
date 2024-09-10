using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetAllProductsByPaging
{
    public class GetAllProductsByPagingQueryRequest : IRequest<List<GetAllProductsByPagingQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
