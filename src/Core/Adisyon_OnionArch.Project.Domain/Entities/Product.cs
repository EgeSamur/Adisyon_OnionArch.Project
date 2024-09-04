using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
