using Adisyon_OnionArch.Project.Application.Common.JWT;
using Adisyon_OnionArch.Project.Application.Interfaces.JWT;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Adisyon_OnionArch.Project.Application.Common.RoleClaimsPrincipal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

namespace Adisyon_OnionArch.Project.Infrastracture.JWT
{
    public class TokenServices : ITokenService
    {
        private readonly TokenSettings _tokenSettings;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        public TokenServices(IOptions<TokenSettings> options, UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor, RoleManager<Role> roleManager)
        {
            _tokenSettings = options.Value;
            _userManager = userManager;
            _optionsAccessor = optionsAccessor;
            _roleManager = roleManager;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Kullanıcının rol ve rol bazlı claim'lerini eklemek için RoleClaimsPrincipalFactory kullanıyoruz
            var claimsPrincipalFactory = new RoleClaimsPrincipalFactory(_userManager, _roleManager, _optionsAccessor);
            var identity = await claimsPrincipalFactory.GenerateClaimsCustomAsync(user);

            // Rol bazlı claim'leri JWT claim'lerine ekliyoruz
            claims.AddRange(identity.Claims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));
            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidatyInMunites),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters 
            { 
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret)),
                ValidateLifetime = false,
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
            if(securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.
                Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token Bulunamadı.");
            }

            return principal;
        }
    }
}
