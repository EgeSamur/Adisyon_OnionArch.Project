using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Delete
{
    public class DeleteCategoryCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
