using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddItemsToBaskets
{
    public class AddItemsToBasketCommandRequest : IRequest<Unit>
    {
        public Guid TableId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
