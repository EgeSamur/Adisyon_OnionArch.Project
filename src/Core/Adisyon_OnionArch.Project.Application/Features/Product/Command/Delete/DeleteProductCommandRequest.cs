using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Delete
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
