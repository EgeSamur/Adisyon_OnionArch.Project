using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Features.Auth.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        private readonly IUnitOfWork _unitofWork;

        public AuthRules(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public Task EnsureUserNotExists(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        } 
    }
}
