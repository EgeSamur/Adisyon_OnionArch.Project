using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions
{
    public class UserDoesNotExistException : BaseException
    {
        public UserDoesNotExistException() : base("User does not exist") { }
    }
}
