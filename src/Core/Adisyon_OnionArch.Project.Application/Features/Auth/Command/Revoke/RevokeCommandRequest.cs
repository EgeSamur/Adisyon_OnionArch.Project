using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandRequest : IRequest<Unit>
    {
        public  string Email { get; set; }
    }
}
