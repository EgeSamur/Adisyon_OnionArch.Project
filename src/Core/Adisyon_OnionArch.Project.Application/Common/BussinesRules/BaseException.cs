namespace Adisyon_OnionArch.Project.Application.Common.BussinesRules
{
    public class BaseException : ApplicationException
    {
        public BaseException() { }
        public BaseException(string message) : base(message){ }
    }
}
