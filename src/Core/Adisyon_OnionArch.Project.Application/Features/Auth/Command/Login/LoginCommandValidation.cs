using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Email).NotEmpty()
             .MaximumLength(50)
             .EmailAddress()
             .MinimumLength(8);

            RuleFor(x => x.Password).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(6);
        }
    }
}
