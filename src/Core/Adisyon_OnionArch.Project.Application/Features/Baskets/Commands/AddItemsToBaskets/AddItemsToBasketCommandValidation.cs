using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddItemsToBaskets
{
    public class AddItemsToBasketCommandValidation : AbstractValidator<AddItemsToBasketCommandRequest>
    {
        public AddItemsToBasketCommandValidation()
        {
            RuleFor(x=>x.ProductId).NotEmpty();
            RuleFor(x=>x.TableId).NotEmpty();
            RuleFor(x=>x.Quantity).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
