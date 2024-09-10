using Adisyon_OnionArch.Project.Application.Dtos;
using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddMoreThanOneItemsToBaskets
{
    public class AddMoreThanOneItemsToBasketsCommandRequest : IRequest<Unit>
    {
        public Guid TableId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
    }
}
