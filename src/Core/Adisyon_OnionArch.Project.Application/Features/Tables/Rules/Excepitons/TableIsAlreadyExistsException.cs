using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Rules.Excepitons
{
    public class TableIsAlreadyExistsException : BaseException
    {
        public TableIsAlreadyExistsException() :base ("Table already Exists.") { }
    }
}
