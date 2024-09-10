using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Delete
{
    public class DeleteTableCommandValidation : AbstractValidator<DeleteTableCommandRequest>
    {
        public DeleteTableCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
               
        }

       
    }
}
