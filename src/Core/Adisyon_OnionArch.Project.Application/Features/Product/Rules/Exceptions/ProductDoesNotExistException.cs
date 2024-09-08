using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Rules.Exceptions
{
    public class ProductDoesNotExistException : BaseException
    {
        public ProductDoesNotExistException() : base("Product does not exist.")
        {
            
        }
    }
}
