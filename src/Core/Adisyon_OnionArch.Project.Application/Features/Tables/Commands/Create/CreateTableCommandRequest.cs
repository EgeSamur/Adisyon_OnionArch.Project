using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create
{
    public class CreateTableCommandRequest : IRequest<Unit>
    {
        public string TableNumberString { get; set; }
    }
}
