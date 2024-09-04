using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        // A category can have multiple products
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
