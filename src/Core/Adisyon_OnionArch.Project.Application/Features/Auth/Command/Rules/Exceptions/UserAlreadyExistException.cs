using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("User already exists.") { }
    }
}
