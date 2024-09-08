using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Create
{
    public class CreateCategoryCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
