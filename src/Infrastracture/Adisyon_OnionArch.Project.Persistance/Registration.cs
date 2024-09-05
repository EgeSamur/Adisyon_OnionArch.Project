using Adisyon_OnionArch.Project.Application.Common.RoleClaimsPrincipal;
using Adisyon_OnionArch.Project.Application.Interfaces.Repositories;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities.Auth;
using Adisyon_OnionArch.Project.Persistance.Context;
using Adisyon_OnionArch.Project.Persistance.Repositories;
using Adisyon_OnionArch.Project.Persistance.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adisyon_OnionArch.Project.Persistance
{
    public static class Registration
    {
        public static void RegisterPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //Repository DPI'ı
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            // UnitOFWorks DPI'ı
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            
            services.AddScoped<IUserClaimsPrincipalFactory<User>, RoleClaimsPrincipalFactory>();
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddClaimsPrincipalFactory<RoleClaimsPrincipalFactory>()  // Doğru metot budur
                    ;
        }
    }
}
