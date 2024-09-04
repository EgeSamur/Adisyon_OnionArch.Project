using Adisyon_OnionArch.Project.Application.Interfaces.Repositories;
using Adisyon_OnionArch.Project.Persistance.Context;
using Adisyon_OnionArch.Project.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adisyon_OnionArch.Project.Persistance
{
    public static class Registration
    {
        public static void RegisterPersistance(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //Repository DPI'ı
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        }
    }
}
