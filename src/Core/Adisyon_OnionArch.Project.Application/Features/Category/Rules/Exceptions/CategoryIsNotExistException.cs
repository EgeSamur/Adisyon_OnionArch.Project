using Adisyon_OnionArch.Project.Application.Common.BussinesRules;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Rules.Exceptions
{
    public class CategoryIsNotExistException : BaseException
    {
        public CategoryIsNotExistException() : base("Category does not exist.") { }
    }
}
