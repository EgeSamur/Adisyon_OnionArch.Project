using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
