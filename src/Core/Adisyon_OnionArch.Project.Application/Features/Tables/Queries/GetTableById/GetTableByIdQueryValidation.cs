using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById
{
    public class GetTableByIdQueryValidation : AbstractValidator<GetTableByIdQueryRequest>
    {
        public GetTableByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
