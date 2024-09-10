using Adisyon_OnionArch.Project.Application.Dtos;
using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddMoreThanOneItemsToBaskets
{
    public class AddMoreThanOneItemsToBasketsCommandValidator : AbstractValidator<AddMoreThanOneItemsToBasketsCommandRequest>
    {
        public AddMoreThanOneItemsToBasketsCommandValidator()
        {
            RuleFor(x => x.TableId)
                .NotEmpty();

            RuleFor(x => x.BasketItems)
                .NotEmpty();

            // Her bir BasketItemDto için ayrı validasyon
            RuleForEach(x => x.BasketItems).SetValidator(new BasketItemDtoValidator());
        }
    }

    public class BasketItemDtoValidator : AbstractValidator<BasketItemDto>
    {
        public BasketItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}
