using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Common.Hashing;
using Adisyon_OnionArch.Project.Application.Features.Auth.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            // bu emailli user var mı
            await _authRules.EnsureUserNotExists(await _userManager.FindByEmailAsync(request.Email));

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            User user = _mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            // Hashlenmiş şifre ve salt'ı kullanıcıya ekliyoruz
            user.PasswordHash = passwordHash.ToString();
            user.PasswordSalt = passwordSalt;

            // Kullanıcıyı veritabanına kaydediyoruz
            IdentityResult result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                // "user" rolü yoksa oluştur
                if (!await _roleManager.RoleExistsAsync("user"))
                {
                    var newRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    };
                    await _roleManager.CreateAsync(newRole);

                    // Rol için default claim ekle
                    await AddDefaultRoleClaimIfNotExists(newRole);
                }

                // Kullanıcıya rol atama
                await _userManager.AddToRoleAsync(user, "user");

                // Kullanıcıya varsayılan claim ekleme
                await AddDefaultUserClaimIfNotExists(user);
            }
            return await Unit.Task;
        }


        private async Task AddDefaultUserClaimIfNotExists(User user)
        {
            // Claim olup olmadığını kontrol ediyoruz
            var existingClaims = await _userManager.GetClaimsAsync(user);
            var defaultClaimType = "IsDefaultUser";
            var defaultClaimValue = "true";

            // Eğer zaten bu claim varsa tekrar eklemiyoruz
            if (!existingClaims.Any(c => c.Type == defaultClaimType && c.Value == defaultClaimValue))
            {
                // Claim ekleniyor
                var defaultClaim = new Claim(defaultClaimType, defaultClaimValue);
                await _userManager.AddClaimAsync(user, defaultClaim);
            }
        }

        private async Task AddDefaultRoleClaimIfNotExists(Role role)
        {
            // Rol için claim olup olmadığını kontrol ediyoruz
            var existingRoleClaims = await _roleManager.GetClaimsAsync(role);
            var defaultClaimType = "IsDefaultRole";
            var defaultClaimValue = "true";

            // Eğer claim yoksa ekliyoruz
            if (!existingRoleClaims.Any(c => c.Type == defaultClaimType && c.Value == defaultClaimValue))
            {
                // Yeni claim ekleniyor
                var defaultRoleClaim = new Claim(defaultClaimType, defaultClaimValue);
                await _roleManager.AddClaimAsync(role, defaultRoleClaim);
            }
        }
    }

   
}
