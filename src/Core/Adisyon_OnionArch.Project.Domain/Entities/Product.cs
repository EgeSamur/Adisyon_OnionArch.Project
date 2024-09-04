using Adisyon_OnionArch.Project.Domain.Common;
using Adisyon_OnionArch.Project.Domain.Enums;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public  bool? IsBestSeller { get; set; }
        public BestSellerRank? BestSellerRank { get; set; }


        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
