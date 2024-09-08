using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Update
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
