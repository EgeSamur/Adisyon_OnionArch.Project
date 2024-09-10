using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging
{
    public class GetAllTablesByPagingQueryRequest : IRequest<List<GetAllTablesByPagingQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
