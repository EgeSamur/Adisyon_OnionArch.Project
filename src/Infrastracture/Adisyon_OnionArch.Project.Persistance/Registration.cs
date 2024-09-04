using Adisyon_OnionArch.Project.Persistance.Context;
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
        
        }
    }
}
