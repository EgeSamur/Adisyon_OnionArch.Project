using Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Exceptions;
using Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Logging.Serilog;
using Adisyon_OnionArch.Project.Application.Interfaces.Logger;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Adisyon_OnionArch.Project.Application
{
    public static class Registration
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Exception middleware DPI
            services.AddTransient<ExceptionMiddleware>();

            services.AddSingleton<ILoggerCustom, LoggerCustom>();
        }
    }
}
