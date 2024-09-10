using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Rules.Exceptions
{
    public class BasketDoesNotExistsException : BaseException
    {
        public BasketDoesNotExistsException() : base("Table id does not have a Basket or basket is not paid .") { }
    }
}
