using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById
{
    public class GetTableByIdQueryRequest : IRequest<GetTableByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
