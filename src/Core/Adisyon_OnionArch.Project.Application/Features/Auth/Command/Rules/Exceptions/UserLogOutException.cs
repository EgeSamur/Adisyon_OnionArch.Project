using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions
{
    public class UserLogOutException : BaseException
    {
        public UserLogOutException() : base("Session time has expired. Please log in again.") { }
        
    }
}
