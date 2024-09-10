using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Rules.Excepitons
{
    public class TableDoesNotExistException : BaseException
    {
        public TableDoesNotExistException() : base("Table does not exist.") { }
    }
}
