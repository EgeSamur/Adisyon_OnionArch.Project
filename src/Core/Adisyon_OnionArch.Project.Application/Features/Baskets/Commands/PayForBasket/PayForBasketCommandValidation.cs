using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.PayForBasket
{
    public class PayForBasketCommandValidation : AbstractValidator<PayForBasketCommandRequest>
    {
        public PayForBasketCommandValidation()
        {
            RuleFor(x=> x.BasketId).NotEmpty();
        }
    }
}
