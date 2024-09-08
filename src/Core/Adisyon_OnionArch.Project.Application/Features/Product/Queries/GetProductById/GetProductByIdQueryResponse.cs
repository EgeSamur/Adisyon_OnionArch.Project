using Adisyon_OnionArch.Project.Domain.Entities;
using Adisyon_OnionArch.Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsBestSeller { get; set; }
        public BestSellerRank? BestSellerRank { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
