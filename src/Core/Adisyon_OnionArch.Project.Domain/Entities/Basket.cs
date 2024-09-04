using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class Basket : EntityBase
    {
        public Guid TableId { get; set; }
        public bool IsPaid { get; set; } = false;

        // A bucket can have multiple items
        public ICollection<BasketItem> BucketItems { get; set; }

        // Navigation property
        public Table Table { get; set; }
    }
}
