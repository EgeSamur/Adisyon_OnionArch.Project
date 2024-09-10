using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.PayForBasket
{
    public class PayForBasketCommandRequest : IRequest<Unit>
    {
        public Guid BasketId { get; set; }  // Ödenmek istenen sepetin Id'si
    }
}
