using Adisyon_OnionArch.Project.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Adisyon_OnionArch.Project.CustomMapper
{
    public static class Registration
    {
        public static void RegisterCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
