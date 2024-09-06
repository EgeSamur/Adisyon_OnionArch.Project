using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions
{
    public class PasswordDoesNotMatchException : BaseException
    {
        public PasswordDoesNotMatchException() : base("Wrong password.") { }
    }
}
