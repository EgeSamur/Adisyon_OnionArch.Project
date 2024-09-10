using Adisyon_OnionArch.Project.Domain.Entities;

namespace Adisyon_OnionArch.Project.Application.Dtos
{
    public class BasketItemDto
    {
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
