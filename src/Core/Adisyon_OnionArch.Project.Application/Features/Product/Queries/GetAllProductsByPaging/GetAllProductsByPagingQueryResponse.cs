using Adisyon_OnionArch.Project.Application.Dtos;
using Adisyon_OnionArch.Project.Domain.Enums;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetAllProductsByPaging
{
    public class GetAllProductsByPagingQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsBestSeller { get; set; }
        public BestSellerRank? BestSellerRank { get; set; }
        public ICollection<CategoryDto>? Categories { get; set; }
    }
}
