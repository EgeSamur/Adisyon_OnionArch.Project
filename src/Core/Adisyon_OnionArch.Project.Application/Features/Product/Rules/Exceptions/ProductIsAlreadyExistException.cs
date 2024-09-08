using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Rules.Exceptions
{
    public class ProductIsAlreadyExistException : BaseException
    {
        public ProductIsAlreadyExistException() : base("Product is already exists.") { }
    }
}
