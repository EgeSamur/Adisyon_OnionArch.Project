using Adisyon_OnionArch.Project.Application.Common.JWT;
using Adisyon_OnionArch.Project.Application.Interfaces.JWT;
using Adisyon_OnionArch.Project.Infrastracture.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Adisyon_OnionArch.Project.Infrastracture
{
    public static class Registration
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configration)
        {
            services.Configure<TokenSettings>(configration.GetSection("JWT"));
        
            services.AddTransient<ITokenService,TokenServices>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configration["JWT:Issuer"],
                    ValidAudience = configration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
