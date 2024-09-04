using Adisyon_OnionArch.Project.Domain.Common;
using System.Net.Sockets;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class BasketItem : EntityBase
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
