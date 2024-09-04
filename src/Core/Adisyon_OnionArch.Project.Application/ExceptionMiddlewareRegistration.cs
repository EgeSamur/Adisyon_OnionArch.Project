using Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace Adisyon_OnionArch.Project.Application
{
    public static class ExceptionMiddlewareRegistration
    {

        public static void AddConfigureGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
