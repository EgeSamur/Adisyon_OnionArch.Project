using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Common.Hashing;
using Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules.Exceptions;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Rules
{
    public class AuthRules : BaseRules
    {

        public Task EnsureUserNotExists(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EnsureUserExists(User? user)
        {
            if (user is null) throw new UserDoesNotExistException();
            return Task.CompletedTask;
        }

        public Task EnsurePasswordIsCorrect(User user, string password)
        {
            bool isPasswordMatch = HashingHelper.VerifyPasswordHash(password, user.PaswordHashByte, user.PasswordSalt);
            if (!isPasswordMatch) { throw new PasswordDoesNotMatchException(); }
            return Task.CompletedTask;
        }

        public Task EnsureUserNotLogOut(DateTime? refreshTokenExpireTime)
        {
            if (refreshTokenExpireTime <= DateTime.Now)
            {
                throw new UserLogOutException();
            }
            return Task.CompletedTask;
        }
    }

}
