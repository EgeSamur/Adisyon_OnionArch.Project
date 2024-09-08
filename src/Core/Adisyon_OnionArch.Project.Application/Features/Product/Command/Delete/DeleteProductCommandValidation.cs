using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Delete
{
    public class DeleteProductCommandValidation : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
