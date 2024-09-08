using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
