using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Features.Baskets.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules.Excepitons;
using Adisyon_OnionArch.Project.Domain.Entities;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Rules
{
    public class BasketRules : BaseRules
    {
        public async Task<Task> EnsureBasketIsExist(Basket? basket)
        {
            if (basket is null)
            {
                throw new BasketDoesNotExistsException();
            }
            return Task.CompletedTask;
        }
    }
}
