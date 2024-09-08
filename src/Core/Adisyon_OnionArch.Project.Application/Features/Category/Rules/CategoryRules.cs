using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules.Exceptions;
using Adisyon_OnionArch.Project.Domain.Entities;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Rules
{
    public class CategoryRules : BaseRules
    {
        public Task EnsureCategoryIsNotExist(Domain.Entities.Category? category)
        {
            if (category is not null) throw new CategoryIsAlreadyExistsException();
            return Task.CompletedTask;
        }

        public Task EnsureCategoryIsExists(Domain.Entities.Category? category)
        {
            if (category is null) throw new CategoryIsNotExistException();
            return Task.CompletedTask;
        }


    }
}
    
