using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryValidation : AbstractValidator<GetProductByIdQueryRequest>
    {
        public GetProductByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
