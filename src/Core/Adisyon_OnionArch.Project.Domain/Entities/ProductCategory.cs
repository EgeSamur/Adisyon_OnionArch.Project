using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class ProductCategory : EntityBase
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
