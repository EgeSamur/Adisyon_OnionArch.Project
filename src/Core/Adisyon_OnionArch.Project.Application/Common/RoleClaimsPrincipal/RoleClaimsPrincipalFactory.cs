using Adisyon_OnionArch.Project.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Common.RoleClaimsPrincipal
{
    public class RoleClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public RoleClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public  async Task<ClaimsIdentity> GenerateClaimsCustomAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            return identity;
        }


    }
}
