using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById;
using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
