using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2);

            RuleFor(x => x.Email).NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .MinimumLength(8); 

            RuleFor(x => x.Password).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(6); 

            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(6)
                .Equal(x=>x.Password);

        }
    }
}
